using CSC348Assignment2.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC348Assignment2.Data
{
    public class InitUsers
    {
        public static async Task Init(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            context.Database.EnsureCreated();

            string role1 = "admin";
            string desc1 = "Adminsitrator role, includes highest privilages.";

            string role2 = "commenter";
            string desc2 = "Commenter role, allows you to comment on posts";

            string password = "P@ssw0rd";

            if (await roleManager.FindByNameAsync(role1) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role1, desc1));
            }
            if(await roleManager.FindByNameAsync(role2) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role2, desc2));
            }

            if (await userManager.FindByNameAsync("admin@admin.com") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com",
                    PhoneNumber = "0123456789"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role1);
                }
            }

            if (await userManager.FindByNameAsync("user@user.com") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "user@user.com",
                    Email = "user@user.com",
                    PhoneNumber = "9876543210"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role2);
                }
            }

        }
    }
}
