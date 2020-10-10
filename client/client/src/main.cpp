#include "crypto/sealedbox.hpp"
#include "http/http.hpp"
#include "auth/hwid.hpp"
#include "auth/validation.hpp"

std::int32_t main()
{
    sodium_init();

    ls::validation v( "localhost:8001", "DUx1Laid4QYY2IhUl0jg9JyP74y7esKDCSVn49Ix6Fc=" );
     // 400: Bad Request
     // 401: Unauthorized
    if( !v.login( "test-user" ) ) {
        return -1;
    }

    std::vector<ls::validation::subscription_type> subs;
    if( !v.get_subscriptions( subs ) ) {
        return -1;
    }

    std::string file;
    if( !v.get_product( std::get<1>( subs.front() ), file ) ) {
        return -1;
    }

    printf( "ok!\n" );
    getchar();

    return 0;
}
