using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TalabatSmartVillage.Services.Interfaces;

namespace TalabatSmartVillage.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (User.Identity?.IsAuthenticated == true)
                return RedirectToAction("Index", "Restaurant");

            var categories   = await _homeService.GetCategoriesAsync();
            ViewBag.Restaurants = await _homeService.GetRestaurantsAsync();

            return View(categories);
        }

        [HttpGet]
        public IActionResult Privacy() => View();
    }
}
