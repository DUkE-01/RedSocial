using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedSocial.Core.Application.Interfaces.Services;

namespace RedSocial.Controllers
{
    [Authorize]
    public class AmigosController : Controller
    {
        private readonly IUserApplication _userApplication;
        private readonly IAmigosService _amigosService;
        public async Task<IActionResult> Follow(string username)
        {
            var user = await _userApplication.GetByUserName(username);


            if (!user.HasError)
            {
                var Siguiendo = await _amigosService.Follow(user.ID);

                if (Siguiendo != null)
                {
                    return RedirectToRoute(new { controller = "Amigo", action = "Index" });
                }

            }

            return RedirectToRoute(new { controller = "Amigo", action = "Index" });

        }
    }
}
