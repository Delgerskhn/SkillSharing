using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;

namespace WebApi.Helpers
{
    public static class IdentityDataInitializer
    {
        public static void SeedData
        (UserManager<AppUser> userManager)
        {
            SeedUsers(userManager);
        }

        public static void SeedUsers
        (UserManager<AppUser> userManager)
        {
            if (userManager.FindByNameAsync
("Admin").Result == null)
            {
                AppUser user = new AppUser();
                user.UserName = "Admin";
                user.Email = "Admin@localhost";

                IdentityResult result = userManager.CreateAsync
                (user, "Pass1234!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                                        "Admin").Wait();
                }
            }


        }
    }
}
