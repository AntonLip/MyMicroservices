using IdentityModel;
using IdentitySerrver4.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Linq;
using System.Security.Claims;
using IdentitySerrver4.Models;
using Microsoft.EntityFrameworkCore;

namespace IdentitySerrver4
{
    public class SeedData
    {
        public static async System.Threading.Tasks.Task EnsureSeedDataAsync(string connectionString)
        {
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddDbContext<AppDBContext>(options =>
               options.UseSqlServer(connectionString));

            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDBContext>()
                .AddDefaultTokenProviders();

            using (var serviceProvider = services.BuildServiceProvider())
            {
                using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var context = scope.ServiceProvider.GetService<AppDBContext>();
                    context.Database.Migrate();
                    try
                    {
                        var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                        var admin =  userMgr.FindByNameAsync("admin").Result;
                        if (admin is null)
                        {
                             admin = new AppUser
                            {
                                UserName = "admin",
                                Email = "admin@email.com",
                                EmailConfirmed = true
                            };
                            var result = userMgr.CreateAsync(admin, "5046859Lipl!").Result;
                            if (!result.Succeeded)
                            {
                                throw new Exception(result.Errors.First().Description);
                            }

                            result =  userMgr.AddClaimsAsync(admin, new Claim[]{
                            new Claim(JwtClaimTypes.Name, "admin"),
                            new Claim(JwtClaimTypes.GivenName, "Anton"),
                            new Claim(JwtClaimTypes.FamilyName, "Liplianin"),
                            new Claim(JwtClaimTypes.WebSite, "http://admin.com"),
                            new Claim(JwtClaimTypes.Role, "Admin"),
                            new Claim(JwtClaimTypes.PhoneNumber, "295046859"),
                            new Claim("location", "somewhere")
                        }).Result;
                            if (!result.Succeeded)
                            {
                                throw new Exception(result.Errors.First().Description);
                            }
                            
                            Log.Debug("admin created");
                        }
                        else
                        {
                            Log.Debug("admin already exists");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    };

                }
            }
        }
    }
}
