using IdentitySerrver4.Data;
using IdentitySerrver4.Models;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Reflection;

namespace IdentitySerrver4
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }
        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            Environment = environment;
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            Microsoft.IdentityModel.Logging.IdentityModelEventSource.ShowPII = true;

            const string connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;database=MyIdentityServer4;trusted_connection=yes;";
            var connectionStringUser = @"Data Source=(LocalDb)\MSSQLLocalDB;database=MyIdentityServer4Users;trusted_connection=yes;";

            services.AddDbContext<Data.AppDBContext>(options =>
                options.UseSqlServer(connectionStringUser)
             );

            services.AddIdentity<AppUser, IdentityRole>()
               .AddEntityFrameworkStores<AppDBContext>()
               .AddDefaultTokenProviders();

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
            //services.AddTransient<IEmailSender, EmailSender>();
            var cors = new DefaultCorsPolicyService(new LoggerFactory().CreateLogger<DefaultCorsPolicyService>())
            {
                AllowAll = true
            };
            services.AddSingleton<ICorsPolicyService>(cors);
            var builer = services.AddIdentityServer(options =>
            {
               // options.Discovery.CustomEntries.Add("admin_api", "~/Admin");
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
                options.EmitStaticAudienceClaim = true;
            })

                .AddInMemoryPersistedGrants()               
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = b => b.UseSqlServer(connectionString,
                        sql => sql.MigrationsAssembly(migrationsAssembly));
                })
              .AddOperationalStore(options =>
              {
                  options.ConfigureDbContext = b => b.UseSqlServer(connectionString,
                      sql => sql.MigrationsAssembly(migrationsAssembly));
              })
              .AddAspNetIdentity<AppUser>();


            builer.AddDeveloperSigningCredential();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            InitializeDatabase(app);

            app.UseDeveloperExceptionPage();
            app.UseCors();
            app.UseStaticFiles();
            app.UseIdentityServer();

            app.UseMvcWithDefaultRoute();

        }
        private void InitializeDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();

                var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
                context.Database.Migrate();
                if (!context.Clients.Any())
                {
                    foreach (var client in Config.GetAllClients())
                    {
                        context.Clients.Add(client.ToEntity());
                    }
                    context.SaveChanges();
                }

                if (!context.IdentityResources.Any())
                {
                    foreach (var resource in Config.IdentityResources)
                    {
                        context.IdentityResources.Add(resource.ToEntity());
                    }
                    context.SaveChanges();
                }

                if (!context.ApiResources.Any())
                {
                    foreach (var resource in Config.ApiResources)
                    {
                        context.ApiResources.Add(resource.ToEntity());
                    }
                    context.SaveChanges();
                }
                if (!context.ApiScopes.Any())
                {
                    foreach (var resource in Config.ApiScopes)
                    {
                        context.ApiScopes.Add(resource.ToEntity());
                    }
                    context.SaveChanges();

                }

            }
        }

    }
}
