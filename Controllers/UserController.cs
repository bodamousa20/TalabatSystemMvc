using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TalabatSmartVillage.Auth;
using TalabatSmartVillage.Services.Interfaces;
using TalabatSmartVillage.ViewModel.UserViewModels;

namespace TalabatSmartVillage.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserManager<AppUser> _userManager;

        public UserController(IUserService userService, UserManager<AppUser> userManager)
        {
            _userService  = userService;
            _userManager  = userManager;
        }

        // GET: User/Index
        [HttpGet]
        public async Task<IActionResult> Index(int page = 1)
        {
            var userId = _userManager.GetUserId(User);
            if (string.IsNullOrWhiteSpace(userId))
                return Challenge();

            var model = await _userService.GetOrderHistoryAsync(userId, page);
            return View(model);
        }

        // GET: User/Profile
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var userId = _userManager.GetUserId(User);
            if (string.IsNullOrWhiteSpace(userId))
                return Challenge();

            var model = await _userService.GetProfileAsync(userId);
            if (model == null)
                return Challenge();

            ViewData["StatusMessage"] = TempData["StatusMessage"];
            return View(model);
        }

        // POST: User/Profile
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Profile(UserProfileViewModel model)
        {
            

            var userId = _userManager.GetUserId(User);
            if (string.IsNullOrWhiteSpace(userId))
                return Challenge();

            var result = await _userService.UpdateProfileAsync(userId, model);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error);

                return View(model);
            }

            TempData["StatusMessage"] = "Profile updated successfully.";
            return RedirectToAction(nameof(Profile));
        }
    }
}
