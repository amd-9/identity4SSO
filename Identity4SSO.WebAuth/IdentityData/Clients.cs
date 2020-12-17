using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity4SSO.WebAuth.IdentityData
{
    internal class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "spa client",
                    ClientName = "Implicit SPA Client",
                    ProtocolType = "oidc",
                    ClientUri =  "http://localhost:5003",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    IdentityTokenLifetime = 300,
                    AccessTokenLifetime = 1800,
                    AuthorizationCodeLifetime = 300,
                    AbsoluteRefreshTokenLifetime = 2592000,
                    SlidingRefreshTokenLifetime = 1296000,
                    RefreshTokenUsage = TokenUsage.ReUse,
                    EnableLocalLogin = true,
                    RequireConsent = false,
                    AllowedCorsOrigins = new List<string> { "http://localhost:5003" },
                    RedirectUris = new List<string> { "http://localhost:5003/signin-oidc" },
                    PostLogoutRedirectUris = { "http://localhost:5003/signout-oidc" },
                    AllowedScopes = new List<string> {"openid", "profile", "api"}
                }
            };
        }
    }
}
