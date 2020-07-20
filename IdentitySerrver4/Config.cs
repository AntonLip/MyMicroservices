using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentitySerrver4
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
          new List<IdentityResource>
                {
                    new IdentityResources.OpenId(),
                    new IdentityResources.Profile(),
                    new IdentityResources.Email()
                };
        
        public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new ApiScope("api1", "My API"),
            new ApiScope("api2", "Their Api")
        };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("api1", "My API")
            };

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser> {
            new TestUser
            {
                SubjectId = "1",
                Username = "alice",
                Password = "alice",
                Claims =
                    {
                        new Claim(JwtClaimTypes.Name, "Alice Smith"),
                        new Claim(JwtClaimTypes.Email, "AliceSmith@email.com")
                    },
                
            },
                new TestUser
                {
                    SubjectId = "11",
                    Username = "bob",
                    Password = "bob",
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Name, "Bob Smith"),
                        new Claim(JwtClaimTypes.Email, "BobSmith@email.com")
                    }
                }
            };
                
        }
        
        public static IEnumerable<Client> GetAllClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "api1" }
                },
                new Client
                {
                    ClientId = "whether.client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                    new Secret("secret1".Sha256())
                    },
                    AllowedScopes = { "api2" }
                },
                 new Client
                {
                    ClientId = "SPA.client",
                    ClientName = "SPA",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,
                    ClientSecrets =
                    {
                    new Secret("SecretSPA".Sha256())
                    },
                    RedirectUris = { "http://localhost:3000/Login" },
                    PostLogoutRedirectUris = { "http://localhost:3000/" },
                    AllowedScopes =
                     {
                         IdentityServerConstants.StandardScopes.OpenId,
                         IdentityServerConstants.StandardScopes.Profile,
                          IdentityServerConstants.StandardScopes.Email,
                         "api1"
                     },
                     AllowOfflineAccess = true
                }
            };
         }
    }
}
