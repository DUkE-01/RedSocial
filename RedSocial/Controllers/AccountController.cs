﻿
using Microsoft.AspNetCore.Mvc;
using RedSocial.Core.Application.Dtos.Account;
using RedSocial.Core.Application.Dtos.User;
using RedSocial.Core.Application.Interfaces.Services;
using RedSocial.Core.Application.ViewModels.Usuario;
using RedSocial.Core.Application.Helpers;
using RedSocial.Middlewares;
using Microsoft.AspNetCore.Authorization;

namespace RedSocial.Controllers
{
   
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserApplication _userApplication;

        public AccountController(IUserService userService, IUserApplication userApplication)
        {
            _userService = userService;
            _userApplication = userApplication;
        }

        [ServiceFilter(typeof(LoginAuthorize))]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [ServiceFilter(typeof(LoginAuthorize))]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Invalid access data";
                return View();
            }

            AuthenticationResponse userVm = await _userService.LoginAsync(vm);
            if (userVm != null && userVm.HasError != true)
            {

                HttpContext.Session.Set<AuthenticationResponse>("user", userVm);

                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            else
            {
                vm.HasError = userVm.HasError;
                vm.Error = userVm.Error;

                //Como mostrarle el error al usuario ------------
                return View();
            }

        }

        public IActionResult EditProfile()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View(HttpContext.Session.Get<UserResponse>("user"));

        }

        private string UploadFile(IFormFile file, string ID, bool isEditMode = false, string imageURL = "")
        {
            if (isEditMode && file == null)
            {
                return imageURL;
            }
            /* Get file directory */

            string basePath = $"/Users/users/{ID}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");

            // Create user folder if not exists
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            /* Get file path */

            // Gets the name of the original file
            FileInfo fileInfo = new(file.FileName);

            //Create a unique ID
            Guid guid = Guid.NewGuid();

            string fileName = guid + fileInfo.Extension;
            string fileNameWithPath = Path.Combine(path, fileName);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            if (isEditMode)
            {
                string[] oldImagePart = imageURL.Split('/');
                string oldImageName = oldImagePart[^1];
                string completeImageOldPath = Path.Combine(path, oldImageName);

                if (System.IO.File.Exists(completeImageOldPath))
                {
                    System.IO.File.Delete(completeImageOldPath);
                }
            }

            return $"{basePath}/{fileName}";
        }

        public async Task<IActionResult> Registro()
        {
            return View(new SaveUserViewModel());
        }

        [ServiceFilter(typeof(LoginAuthorize))]
        [HttpPost]
        public async Task<IActionResult> Registro(SaveUserViewModel vm)
        {
            if (!ModelState.IsValid) 
            {
                return View("Index", vm);
            }

            var origin = Request.Headers["origin"];

            RegisterResponse response = await _userService.RegisterAsync(vm, origin);

            UserResponse user = await _userApplication.GetByEmailUser(vm.Email);

            UpdateUserViewModel UpdateReVM = new()
            {
                Id = user.ID,
                Email = user.Email
            };

            if (response.HasError != true)
            {
                UpdateReVM.ImageURL = UploadFile(vm.Photo, UpdateReVM.Id);
                await _userService.Update(UpdateReVM);
                return View();
            }

            vm.HasError = response.HasError;
            vm.Error = response.Error;

        
            return RedirectToRoute(new { controller = "User", action = "Index" });
        }

        [ServiceFilter(typeof(LoginAuthorize))]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            var response = await _userService.ConfirmEmailAsync(userId, token);
            return View("ConfirmEmail", response);
        }


         [Authorize]
        public async Task<IActionResult> LogOut()
        {
            await _userService.SignOutAsync();
            HttpContext.Session.Remove("user");
            return RedirectToRoute(new { controller = "User", action = "Index" });
        }

        [ServiceFilter(typeof(LoginAuthorize))]
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var origin = Request.Headers["origin"];
            ForgotPasswordResponse response = await _userService.ForgotPasswordAsync(vm, origin);

            if (response.HasError)
            {
                vm.HasError = response.HasError;
                vm.Error = response.Error;

                //como mostrarle el error al usuario ------------------

                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            return RedirectToRoute(new { controller = "User", action = "ForgotPassword" });
        }

        [ServiceFilter(typeof(LoginAuthorize))]
        public IActionResult ForgotPassword()
        {
            return View();
        }


        [ServiceFilter(typeof(LoginAuthorize))]
        public IActionResult ResetPassword(string token, string email)
        {
            return RedirectToAction("ResetPasswordToken", new ResetPasswordViewModel() { Token = token, Email = email });
        }



        public async Task<IActionResult> ResetPasswordToken(ResetPasswordViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            ResetPasswordResponse response = await _userService.ResetPasswordAsync(vm);
            if (response.HasError)
            {
                response.HasError = response.HasError;
                response.Error = response.Error;

                //Como mostrarle el error al usuario -------------
                return View(vm);
            }
            return RedirectToRoute(new { controller = "User", action = "Index" });
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }

}
