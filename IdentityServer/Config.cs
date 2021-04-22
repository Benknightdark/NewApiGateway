using System.Collections.Generic;
using IdentityServer4.Models;
using System;
using System.IO;
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
                        ClientId =Environment.GetEnvironmentVariable("client") ,

                        // no interactive user, use the clientid/secret for authentication
                        AllowedGrantTypes = GrantTypes.ClientCredentials,

                        // secret for authentication
                        ClientSecrets =
                        {
                            new Secret(Environment.GetEnvironmentVariable("secret").Sha256())
                        },

                        // scopes that client has access to
                        AllowedScopes = { Environment.GetEnvironmentVariable("ALLOWSCOPES") }
                    }
            };
    }
}