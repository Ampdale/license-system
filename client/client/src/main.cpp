//#include "VirtualizerSDK.h"

#include "crypto/sealedbox.hpp"
#include "http/http.hpp"
#include "auth/hwid.hpp"
#include "auth/validation.hpp"

std::int32_t main()
{
  //VIRTUALIZER_TIGER_WHITE_START
    sodium_init();

    ls::validation v( "localhost:8001", "DUx1Laid4QYY2IhUl0jg9JyP74y7esKDCSVn49Ix6Fc=" );
    if( !v.login(   "testd" ) ) {
        return -1;
    }

    std::vector<ls::validation::subscription_type> subs;
    if( !v.get_subscriptions( subs ) ) {
        return -1;
    }

  /*  std::string file;
    if( !v.get_product( std::get<1>( subs.front() ), file ) ) {
        return -1;
    }*/

    printf( "ok!\n" );
    getchar();

   //VIRTUALIZER_TIGER_WHITE_END

    return 0;
}
