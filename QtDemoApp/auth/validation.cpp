#include "validation.hpp"
#include "../crypto/xorstr.hpp"
#include "../http/http.hpp"
using namespace ls;
using namespace hide_string;

std::string first_numberstring(std::string const& str)
{
    char const* digits = "0123456789";
    std::size_t const n = str.find_first_of(digits);
    if (n != std::string::npos)
    {
        std::size_t const m = str.find_first_not_of(digits, n);
        return str.substr(n, m != std::string::npos ? m - n : m);
    }
    return std::string();
}

validation::validation(
    const std::string_view& server_url,
    const std::string_view& server_public_key )
    : _server_url( server_url )
{
    _server_key.load_public_key( server_public_key );
}

#define json_ptr(data)\
    nlohmann::json::json_pointer((LPCSTR)xors(data))

template<typename type>
constexpr __forceinline
decltype( auto ) enum_v( const type value )
{
    return static_cast<std::underlying_type_t<type>>( value );
}

bool validation::login(
    const std::string_view& username )
{
    if( username.empty() ) {
        return false;
    }

    const auto j = make_request( request_type::login, {
        { (LPCSTR)xors( "username" ), username },
        { (LPCSTR)xors( "hwid" ), hwid::get_super_secret_info() }
    } );

    const std::int32_t code = j.at( json_ptr( "/code" ) );
    if( static_cast<api_code>( code ) != api_code::success ) {
        return false;
    }

    _username = j.at( json_ptr( "/response/name" ) );
    _user_id  = j.at( json_ptr( "/response/id" ) );;

    return true;
}

bool validation::get_subscriptions(
    std::vector<subscription_type>& subs ) const
{
    const auto j = make_request( request_type::get_subs, {
        { (LPCSTR)xors( "user_id" ), _user_id }
    } );

    const std::int32_t code = j.at( json_ptr( "/code" ) );
    if( static_cast<api_code>( code ) != api_code::success ) {
        return false;
    }

    for( const auto& sub : j.at( json_ptr( "/response" ) ) ) {
        std::string name   = sub.at( json_ptr( "/name" ) );
        std::size_t id     = sub.at( json_ptr( "/id" ) );
        std::int64_t until = sub.at( json_ptr( "/until" ) );

        // получим текущее время с сайта (время на пк можно изменить)
        // если часы спешат, то ответа от сервера не будет (!)
        std::string datetime = ls::http_get("cadzirisoft/?r=unix-time", "", "", 5L);

        if (datetime.empty())
        {
            return false;
        }

        // заберем нужное значение
        auto now = first_numberstring(datetime);

        if (now.empty())
        {
            return false;
        }

        // проверям  
        if ((std::int64_t)std::stoi (now) > until) {
            return false;
        }

        subs.emplace_back( std::make_tuple( std::move( name ), id, until ) );
    }

    return true;
}

bool validation::get_product(
    const std::size_t id,
    std::string&      data ) const
{
    const auto j = make_request( request_type::get_product, {
        { (LPCSTR)xors( "product_id" ), id }
    } );
    
    const std::int32_t code = j.at( json_ptr( "/code" ) );
    if( static_cast<api_code>( code ) != api_code::success ) {
        return false;
    }
    data = j.at( json_ptr("/response") );

    return true;
}

nlohmann::json validation::make_request(
    const request_type         type,
    const nlohmann::json&      data ) const
{
    const sealedbox::key_pair kp;
    nlohmann::json request_data;
    request_data[(LPCSTR)xors( "request" ) ]    = static_cast<std::underlying_type_t<request_type>>( type );
    request_data[(LPCSTR)xors( "public_key" ) ] = kp.get_public_key();

    if( !data.empty() ) {
        request_data[(LPCSTR)xors( "data" ) ] = data;
    }

    const auto http_response = http_post(
        _server_url,
        (LPCSTR)xors( "client" ),
        std::string((LPCSTR)xors( "data=" ) ) + base64::url_encode( sealedbox::encrypt( request_data.dump(), _server_key ) )
    );

    if( http_response.empty() ) {
        return { { (LPCSTR)xors( "code" ), enum_v( api_code::client_empty_resonse ) } };
    }
    if( http_response == (LPCSTR)xors( "Bad Request" ) || http_response == (LPCSTR)xors( "Unauthorized" ) || http_response == (LPCSTR)xors( "Conflict" ) ) {
        return { { (LPCSTR)xors( "code" ), enum_v( api_code::client_bad_response ) } };
    }
    try {
        const auto decrypted_response = sealedbox::decrypt( http_response, kp );
        if( decrypted_response.empty() ) {
            return { { (LPCSTR)xors( "code" ), enum_v( api_code::client_weird_response ) } };
        }

        std::istringstream iss( decrypted_response );
        if( !iss ) {
            return { { (LPCSTR)xors( "code" ), enum_v( api_code::client_weird_response ) } };
        }

        return nlohmann::json::parse( iss );
    }
    catch( ... ) {
        return { { (LPCSTR)xors( "code" ), enum_v( api_code::client_weird_response ) } };
    }
}
