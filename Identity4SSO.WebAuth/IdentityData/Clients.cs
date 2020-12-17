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
                    ClientId = "client",
                    ClientName = "Implicit Client",
                    ProtocolType = "oidc",
                    ClientUri =  "localhost:5003",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RedirectUris = new List<string> { "localhost:5003/callback" },
                    AllowedScopes = new List<string> {"api"}
                }
            };
        }
    }
}
