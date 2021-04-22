using System.Collections.Generic;
using IdentityServer4.Models;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
            new ApiScope("api1", "My API")
            };
        public static IEnumerable<Client> Clients =>new List<Client>
            {
                    new Client
                    {
                        ClientId = "client",

                        // no interactive user, use the clientid/secret for authentication
                        AllowedGrantTypes = GrantTypes.ClientCredentials,

                        // secret for authentication
                        ClientSecrets =
                        {
                            new Secret("qtNtp71M04c/IrH3k2hWxF70ZPpt1kqOnGWmq19fTVZhpC/k8PZ+WmptVXu9lHMxnfGYKr32BWapRLg3+/dUgaa4J4jSEYql/E+GZTb3yCgJ323mIIGi12nBRIp8JKecWmyYw+QRszy75+bl9Lkbbd+trMmrVgn20+rcBG8VOJPl80gvVUYAhjKbQgoSf2kTFMOp7y+AR9avTVQohSy9WecOe41HEjuXORwHLP1eQcKp1T5h9G8daiAnrvki5Qm/W7A+DLj6010Ro36700p9scCiXoZ+CKJdjgK/aRWiplTYahh7nwDbjdf47IwCRZcR0ghUTwrP1TUu3eYSRhT1oA==".Sha256())
                        },

                        // scopes that client has access to
                        AllowedScopes = { "api1" }
                    }
            };
    }
}