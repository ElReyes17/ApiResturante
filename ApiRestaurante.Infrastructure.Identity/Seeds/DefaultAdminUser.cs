

using ApiRestaurante.Core.Application.Enums;
using ApiRestaurante.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;

namespace ApiRestaurante.Infrastructure.Identity.Seeds
{
   public static class DefaultAdminUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            ApplicationUser defaultUser = new();
            defaultUser.UserName = "EL_MEJOR_TEACHER_DE_P3";
            defaultUser.Email = "leonardopanchito22@gmail.com";
            defaultUser.FirstName = "Leonardo";
            defaultUser.LastName = "Miprofe";
            defaultUser.EmailConfirmed = true;
            defaultUser.PhoneNumberConfirmed = true;

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$$word!");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString());
                }
            }

        }
    }
}
