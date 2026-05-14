using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TalabatSmartVillage.Models;

namespace TalabatSmartVillage.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // Redirect authenticated users to restaurants page
            if (User.Identity?.IsAuthenticated == true)
                return RedirectToAction("Index", "Restaurant");

            var categories = await _context.category.ToListAsync();
            ViewBag.Restaurants = _context.restaurant.ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Privacy() => View();
    }
}
