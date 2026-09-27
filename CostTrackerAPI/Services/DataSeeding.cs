using CostTrackerAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace CostTrackerAPI.Services
{
    public static class DataSeeding
    {
        public static async Task SeedAdminUser(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

            var admin = await userManager.FindByEmailAsync("admin@filmrental.se");

            if (admin != null)
            {
                return;
            }

            admin = new User
            {
                UserName = "admin@CostTracker.se",
                Email = "admin@CostTracker.se",
                EmailConfirmed = true
            };

            await userManager.CreateAsync(admin, "Admin123!");

            await userManager.AddToRoleAsync(admin, "Admin");

        }
    }
}
