using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
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

            public AccountController(IAccountservices accountService)
            {
                _accountService = accountService;
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

<<<<<<< Updated upstream
            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(model);
        }

        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            if (User.Identity?.IsAuthenticated == true)
                return RedirectToAction("Index", "Home");
  
            ViewData["ReturnUrl"] = returnUrl;
          return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
=======
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Login(LoginViewModel model)
>>>>>>> Stashed changes
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


        }
}
