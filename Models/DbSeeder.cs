namespace TalabatSmartVillage.Models
{
    using global::TalabatSmartVillage.Auth;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    namespace TalabatSmartVillage.Models
    {
        public static class DbSeeder  // ✅ class was missing
        {
            public static async Task SeedAsync(IServiceProvider services)
            {
                var roleManager = services.GetRequiredService<RoleManager<AppRole>>();
                var userManager = services.GetRequiredService<UserManager<AppUser>>();
                var config = services.GetRequiredService<IConfiguration>();

                // --- Seed Roles ---
                string[] roles = {AppRoles.ADMIN.ToString(), AppRoles.USER.ToString() };
                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                        await roleManager.CreateAsync(new AppRole { Name = role });
                }

                // --- Read from config ---
                var adminEmail = config["SuperAdmin:Email"];
                var adminPassword = config["SuperAdmin:Password"];

                if (await userManager.FindByEmailAsync(adminEmail) == null)
                {
                    var admin = new AppUser
                    {
                        UserName = adminEmail,
                        Email = adminEmail,
                        EmailConfirmed = true,
                        FullName = "Super Admin",
                        CreatedAt = new DateTime(2024, 1, 1),
                    };

                    var result = await userManager.CreateAsync(admin, adminPassword);
                    if (result.Succeeded)
                        await userManager.AddToRoleAsync(admin, "Admin");
                }
            }
        }
    }
}
