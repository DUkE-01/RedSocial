

using Microsoft.AspNetCore.Identity;
using RedSocial.Core.Application.Enums;
using RedSocial.Infraestructure.Identity.Entities;

namespace RedSocial.Infraestructure.Identity.Seed
{
    public static class DefaultUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            ApplicationUser defaultUser = new();
            defaultUser.UserName = "Dark1234";
            defaultUser.Email = "defaultUser@gmail.com";
            defaultUser.FirstName = "Dark";
            defaultUser.LastName = "Johnson";
            defaultUser.PhoneNumber = "+1(809) 000-0000";
            defaultUser.ImageURL = "https://static.nationalgeographicla.com/files/styles/image_3200/public/nationalgeographic_1468962.jpg?w=1600&h=900";
            defaultUser.EmailConfirmed = true;
            defaultUser.PhoneNumberConfirmed = true;

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "#@Dark1234");
                    await userManager.AddToRoleAsync(defaultUser, Roles.User.ToString());

                }
            }



        }
    }
}
