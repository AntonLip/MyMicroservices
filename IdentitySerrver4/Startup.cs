using IdentityServer4.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace IdentitySerrver4
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            Microsoft.IdentityModel.Logging.IdentityModelEventSource.ShowPII = true;
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddCors(setup =>
            {
                setup.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.WithOrigins("http://localhost:3000", "http://localhost:3000");
                    policy.AllowCredentials();
                });
            });
            var cors = new DefaultCorsPolicyService(new LoggerFactory().CreateLogger<DefaultCorsPolicyService>())
            {
                AllowAll = true
            };
            services.AddSingleton<ICorsPolicyService>(cors);
            services.AddIdentityServer(
                options =>
                {
                    options.UserInteraction.LoginUrl = "http://localhost:3000/Login";
                    options.UserInteraction.ErrorUrl = "http://localhost:3000/error";
                    options.UserInteraction.LogoutUrl = "http://localhost:3000/Login";
                })
              .AddDeveloperSigningCredential()
              .AddInMemoryApiScopes(Config.ApiScopes)
              .AddInMemoryClients(Config.GetAllClients())
              .AddInMemoryApiResources(Config.ApiResources);
              //.AddTestUsers(Config.GetUsers())
              //.AddInMemoryIdentityResources(Config.GetIdentityResources())
              //.AddInMemoryApiResources(Config.GetAllApiRespurces())
              

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            app.UseDeveloperExceptionPage();
            app.UseCors();
            app.UseStaticFiles();
            app.UseIdentityServer();

            app.UseMvcWithDefaultRoute();

        }
    }
}
