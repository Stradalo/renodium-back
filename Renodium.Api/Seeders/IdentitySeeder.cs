using Microsoft.AspNetCore.Identity;
using Renodium.Api.Entities;

namespace Renodium.Api.Seeders
{
    public static class IdentitySeeder
    {

        public static async Task SeedAsync(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager) 
        {
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                var appRole = new AppRole
                {
                    Name = "Admin",
                };

                await roleManager.CreateAsync(appRole);
            }

            if (!await roleManager.RoleExistsAsync("User"))
            {
                var appRole = new AppRole
                {
                    Name = "User",
                };

                await roleManager.CreateAsync(appRole);
            }

            var adminUser = await userManager.FindByEmailAsync("admin@renodium.com");

            if (adminUser == null)
            {
                var appUser = new AppUser
                {
                    Email = "admin@renodium.com",
                    UserName = "Admin",
                };

                await userManager.CreateAsync(appUser, "renodiumAdmin{2026}");
                await userManager.AddToRoleAsync(appUser, "Admin");
            }
        }
    }
}
