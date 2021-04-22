using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace ApiGateway
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

            services.AddControllers();
            var authenticationProviderKey = "TestKey";
            Action<JwtBearerOptions> options = o =>
                {
                    o.Authority = "http://identity-server";
                    o.RequireHttpsMetadata=false;
            // etc
        };

            services.AddAuthentication()
                .AddJwtBearer(authenticationProviderKey, options);
            // services.AddAuthentication(x =>
            //     {
            //         x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //         x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //     })
            //     .AddJwtBearer("TestKey",x =>
            //     {
            //         x.RequireHttpsMetadata = false;
            //         x.SaveToken = true;
            //         x.TokenValidationParameters = new TokenValidationParameters
            //         {
            //             ValidateIssuerSigningKey = true,
            //             IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetValue<string>("JWTSecretKey"))),
            //             ValidateIssuer = false,
            //             ValidateAudience = false
            //         };
            //         x.Events = new JwtBearerEvents()
            //          {

            //              OnChallenge = context =>
            //              {
            //                  context.HandleResponse();
            //                  context.Response.WriteAsync(
            //                      System.Text.Json.JsonSerializer.Serialize(
            //                          new 
            //                          {
            //                              status = 401,
            //                              title = "401",
            //                              errors = "需要登入才能使用此功能"
            //                          }));
            //                  return Task.FromResult(0);
            //              }
            //          };
            //     });
            services.AddOcelot();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // 啟用路由
            app.UseRouting();
            // 啟用驗證
            app.UseAuthentication();
            // 啟用授權
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            var configuration = new OcelotPipelineConfiguration
            {
            };

            app.UseOcelot(configuration).Wait(); ;
        }
    }
}
