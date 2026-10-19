using CostTrackerAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace CostTrackerAPI.Data
{
    public class Seeder
    {
        //This method seeds a user with admin priviliges if no such user exists in the DB.
        public static async Task SeedAdminAsync(IServiceProvider services)
        {
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole<int>>>();

            var userManager = services.GetRequiredService<UserManager<User>>();

            const string adminRoleName = "Admin";
            const string adminEmail = "admin@costtracker.com";
            const string adminPassword = "Admin123#";

            if(!await roleManager.RoleExistsAsync(adminRoleName))
            {
                await roleManager.CreateAsync(new IdentityRole<int>(adminRoleName));
            }

            var user = await userManager.FindByEmailAsync(adminEmail);

            if(user == null)
            {
                user = new User
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FirstName = "Admin",
                    LastName = "User"
                };

                var result = await userManager.CreateAsync(user, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, adminRoleName);
                }
            }

            var addRole = await userManager.AddToRoleAsync(user, adminRoleName);

        }
    }
}
