using Identity4SSO.WebAuth.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity4SSO.WebAuth.IdentityData
{
    public static class ApplicationDbInitializer
    {
        public static async Task SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (await userManager.FindByNameAsync("developer") == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "developer",
                    Email = "developer@sso.local",
                    
                };

                IdentityResult result = await userManager.CreateAsync(user, "12345678");
            }
        }
    }
}
