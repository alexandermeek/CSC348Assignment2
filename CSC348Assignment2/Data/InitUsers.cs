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

            string password = "Password123!”";

            //Check if roles have been created yet or not.
            if (await roleManager.FindByNameAsync(role1) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role1, desc1));
            }
            if(await roleManager.FindByNameAsync(role2) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role2, desc2));
            }

            //Check if seeded users have been created yet or not.
            if (await userManager.FindByNameAsync("Member1@email.com") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "Member1",
                    Email = "Member1@email.com",
                    PhoneNumber = "0123456789"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role1);
                }
            }

            for (int i = 1; i <= 5; i++)
            {
                if (await userManager.FindByNameAsync("Customer" + i + "@email.com") == null)
                {
                    var user = new ApplicationUser
                    {
                        UserName = "Customer" + i,
                        Email = "Customer" + i + "@email.com",
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
}
