using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace IdentityServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var ApiScoped = new List<ApiScope>
            {
            new ApiScope( Configuration.GetValue<string>("ALLOWSCOPES") , "My API")
            };
            var ClientsData = new List<Client>{
                new Client
                {
                    ClientId = Configuration.GetValue<string>("CLIENT"),
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                            {
                            new Secret(Configuration.GetValue<string>("SECRET").Sha256())
                            },

                    AllowedScopes = { Configuration.GetValue<string>("ALLOWSCOPES") }
                }
            };


            var builder = services.AddIdentityServer()
                   .AddDeveloperSigningCredential()        
                   .AddInMemoryApiScopes(ApiScoped)
                   .AddInMemoryClients(ClientsData);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseIdentityServer();
        }
    }
}
