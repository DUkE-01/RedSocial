using Microsoft.AspNetCore.Identity;
using RedSocial.Core.Application.Enums;
using RedSocial.Infraestructure.Identity.Entities;


namespace RedSocial.Infraestructure.Identity.Seed
{
    public class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(nameof(Roles.User)));
            

        }
    }
}
