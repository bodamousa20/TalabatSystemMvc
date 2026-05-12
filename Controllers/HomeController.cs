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

            return View(await _context.category.ToListAsync());
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
