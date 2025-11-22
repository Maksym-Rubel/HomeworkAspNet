using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace IDK_Api.Helpers
{

    public static class Roles
    {
        public const string ADMIN = "admin";
        public const string USER = "user";

    }
    public static class IdentityInitializer
    {

        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync(Roles.ADMIN))
                await roleManager.CreateAsync(new (Roles.ADMIN));

            if (!await roleManager.RoleExistsAsync(Roles.USER))
                await roleManager.CreateAsync(new(Roles.USER));
        }

        public static async Task SeedAdminAsync(UserManager<User> userManager)
        {


           

            const string USERNAME = "admin@gmail.com";
            const string PASSWORD = "Maksum2404@4042";

            var existingUser = await userManager.FindByNameAsync(USERNAME);
            if(existingUser == null)
            {
                var user = new User
                {
                    UserName = USERNAME,
                    Email = USERNAME,

                };

                var result = await userManager.CreateAsync(user,PASSWORD);

                if(result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user,Roles.ADMIN);
                }
            }
        }
    }
}
