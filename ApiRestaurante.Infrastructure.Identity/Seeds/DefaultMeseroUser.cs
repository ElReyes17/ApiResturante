using Microsoft.AspNetCore.Identity;
using ApiRestaurante.Core.Application.Enums;
using ApiRestaurante.Infrastructure.Identity.Entities;

namespace ApiRestaurante.Infrastructure.Identity.Seeds
{
    public static class DefaultMeseroUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            ApplicationUser defaultUser = new();
            defaultUser.UserName = "GeraldSilvAdmin";
            defaultUser.Email = "samieunloquito22@gmail.com";
            defaultUser.FirstName = "DomingoClase";
            defaultUser.LastName = "LaRussel";
            defaultUser.EmailConfirmed = true;
            defaultUser.PhoneNumberConfirmed = true;

            if(userManager.Users.All(u=> u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$$word!");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Mesero.ToString());
                }
            }
         
        }
    }
}
