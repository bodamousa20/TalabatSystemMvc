using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Security.Claims;
using TalabatSmartVillage.Auth;
using TalabatSmartVillage.Models;
using TalabatSmartVillage.Repositories.Interfaces;
using TalabatSmartVillage.Repositories.RepoImplementations;
using TalabatSmartVillage.Services;

namespace TalabatSmartVillage.Controllers
{
   

        [AllowAnonymous]
        public class AccountController : Controller
        {
            private readonly IAccountservices _accountService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

            public AccountController(IAccountservices accountService , SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
            {
            _accountService = accountService;
            _signInManager = signInManager;
            _userManager = userManager;
            }

            [HttpGet]
            public IActionResult Register()
            {
                if (User.Identity?.IsAuthenticated == true)
                    return RedirectToAction("Index", "Home");
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Register(RegisterViewModel model)
            {
                if (!ModelState.IsValid)
                    return View(model);

                if (await _accountService.IsEmailTakenAsync(model.Email))
                {
                    ModelState.AddModelError("Email", "An account with this email already exists.");
                    return View(model);
                }

                var result = await _accountService.RegisterAsync(model);
                if (result.Succeeded)
                    return RedirectToAction("Login");

                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error);

                return View(model);
            }

            [HttpGet]
            public IActionResult Login()
            {
                if (User.Identity?.IsAuthenticated == true)
                    return RedirectToAction("Index", "Home");
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Login(LoginViewModel model)
            {
                if (!ModelState.IsValid)
                    return View(model);

                var result = await _accountService.LoginAsync(model);
                if (result.Succeeded)
                    return result.IsAdmin
                        ? RedirectToAction("Dashboard", "Admin")
                        : RedirectToAction("Index", "Home");

                ModelState.AddModelError("", "Invalid email or password.");
                return View(model);
            }

            [Authorize]
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Logout()
            {
                await _accountService.LogoutAsync();
                return RedirectToAction("Login");
            }

        //Google Auth
        [HttpGet]
        public IActionResult GoogleLogin()
        {
            var redirectUrl = Url.Action("GoogleCallback", "Account");
            var properties = _accountService.GetGoogleLoginProperties(redirectUrl);
            return Challenge(properties, "Google");
        }

        [HttpGet]
        public async Task<IActionResult> GoogleCallback()
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ModelState.AddModelError("", "Google login failed.");
                return RedirectToAction("Login");
            }

            // Try sign in if user already used Google before
            var result = await _signInManager.ExternalLoginSignInAsync(
                info.LoginProvider, info.ProviderKey, isPersistent: false);

            if (result.Succeeded)
                return RedirectToAction("Index", "Home");

            // First time — create the user
            var email = info.Principal.FindFirstValue(ClaimTypes.Email);
            var name = info.Principal.FindFirstValue(ClaimTypes.Name);

            var user = new AppUser
            {
                UserName = email,
                Email = email,
                FullName = name  // change to match your model's property
            };

            var createResult = await _userManager.CreateAsync(user);
            if (createResult.Succeeded)
            {
                await _userManager.AddLoginAsync(user, info);
                await _signInManager.SignInAsync(user, isPersistent: false); // ? this is the key line
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in createResult.Errors)
                ModelState.AddModelError("", error.Description);

            return RedirectToAction("Login");
        }


    }
}
