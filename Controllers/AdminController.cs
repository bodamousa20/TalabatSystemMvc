using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TalabatSmartVillage.Auth;
using TalabatSmartVillage.Models;
using TalabatSmartVillage.ViewModel.AdminViewModels;

namespace TalabatSmartVillage.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public AdminController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            var model = new AdminDashboardViewModel
            {
                RestaurantCount = await _context.restaurant.CountAsync(),
                CategoryCount = await _context.category.CountAsync(),
                MenuItemCount = await _context.MenuItem.CountAsync(),
                OrderCount = await _context.Order.CountAsync(),
                UserCount = await _userManager.Users.CountAsync()
            };

            return View(model);
        }
    }
}
