using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace IdentitySerrver4
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
          new List<IdentityResource>
                {
                    new IdentityResources.OpenId(),
                    new IdentityResources.Profile(),
                    new IdentityResources.Email(),
                    new IdentityResources.Phone(),
                    new IdentityResources.Address(),
                    new IdentityResource {
                        Name = "Role",
                        UserClaims = new List<string> { JwtClaimTypes.Role }
                    },
                    new IdentityResource {
                        Name = "family_name",
                        UserClaims = new List<string> { JwtClaimTypes.FamilyName }
                    },
                    new IdentityResource {
                        Name = "given_name",
                        UserClaims = new List<string> { JwtClaimTypes.GivenName }
                    },
                     new IdentityResource {
                        Name = "middle_name",
                        UserClaims = new List<string> { JwtClaimTypes.MiddleName }
                    },
                    new IdentityResource {
                        Name = "position",
                        UserClaims = new List<string> { "position" }
                    },
                    new IdentityResource {
                        Name = "picture",
                        UserClaims = new List<string> { JwtClaimTypes.Picture }
                    }
                };

        public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new ApiScope("api1", "My API"),
            new ApiScope("TimetibleService.read", "TimetibleService.read"),
            new ApiScope("TimetibleService.write", "TimetibleService.write"),
        };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("api1", "My API")
                {
                   
                },
                new ApiResource("TimetibleService", "TimetibleService")
                {
                    Description = "Get or set infomation about timetable",
                    
                }
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

            }
            };

        }

        public static IEnumerable<Client> GetAllClients()
        {
            return new List<Client>
            {
                // machine to machine 
                new Client
                {
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "api1", "api2" }
                },
                // js client
                new Client
                {
                    ClientId = "SPA.client",
                    ClientName = "SPA",
                     ClientSecrets =
                        {
                            new Secret("secret".Sha256())
                        },
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RedirectUris = { "http://localhost:3000/signin-oidc"},
                    PostLogoutRedirectUris = { "http://localhost:3000/signout-callback-oidc" },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Phone,
                        IdentityServerConstants.StandardScopes.Address,
                        "api1",
                        "Role",
                        "family_name",
                        "given_name",
                        "middle_name",
                        "position",
                        "picture"
                    },
                    AllowOfflineAccess = true,
                    AlwaysSendClientClaims = true, // New Code
                    AlwaysIncludeUserClaimsInIdToken = true // New Code
                }
            };
        }
    }
}
