using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TalabatSmartVillage.Extensions;
using TalabatSmartVillage.Models;
using TalabatSmartVillage.Repositories.Interfaces;
using TalabatSmartVillage.ViewModel.CartViewModels;
using TalabatSmartVillage.ViewModel.MenuItemViewModels;
using TalabatSmartVillage.ViewModel.RestaurantViewModels;

namespace TalabatSmartVillage.Controllers
{

    public class RestaurantController : Controller
    {
        private readonly IRestaurantRepo _repo;
        private readonly AppDbContext _context;

        public RestaurantController(IRestaurantRepo repo, AppDbContext context)
        {
            _repo = repo;
            _context = context;
        }

        // GET: RestaurantController
        public ActionResult Index()
        {
            var restaurants = _repo.GetAll();
            return View(restaurants);
        }

        // GET: RestaurantController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var restaurant = _repo.GetById(id);
                return View(restaurant);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Menu(int id, string? search, string? category)
        {
            var restaurant = await _context.restaurant
                .AsNoTracking()
                .Include(r => r.Category)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (restaurant == null)
            {
                return NotFound();
            }

            var menuQuery = _context.MenuItem
                .AsNoTracking()
                .Where(item => item.RestaurantId == id);

            if (!string.IsNullOrWhiteSpace(search))
            {
                menuQuery = menuQuery.Where(item => item.Name.Contains(search) || item.Description.Contains(search));
            }

            if (!string.IsNullOrWhiteSpace(category) && !string.Equals(category, "all", StringComparison.OrdinalIgnoreCase))
            {
                if (string.Equals(category, "available", StringComparison.OrdinalIgnoreCase))
                {
                    menuQuery = menuQuery.Where(item => item.IsAvailable);
                }
                else if (string.Equals(category, "unavailable", StringComparison.OrdinalIgnoreCase))
                {
                    menuQuery = menuQuery.Where(item => !item.IsAvailable);
                }
            }

            var menuItems = await menuQuery
                .OrderBy(item => item.Name)
                .Select(item => new MenuItemCardViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    IsAvailable = item.IsAvailable,
                    Image = item.image,
                    RestaurantId = id,
                    Category = string.Empty
                })
                .ToListAsync();

            foreach (var item in menuItems)
            {
                item.Category = GetMenuCategory(item.Name, item.Description);
            }

            if (!string.IsNullOrWhiteSpace(category) && !string.Equals(category, "all", StringComparison.OrdinalIgnoreCase))
            {
                menuItems = menuItems
                    .Where(item => string.Equals(item.Category, category, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            var bannerImage = await _context.MenuItem
                .AsNoTracking()
                .Where(item => item.RestaurantId == id && item.image != null)
                .Select(item => item.image)
                .FirstOrDefaultAsync();

            var model = new RestaurantMenuViewModel
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                CategoryName = restaurant.Category.Name,
                Address = restaurant.Address,
                IsOpen = restaurant.IsOpen,
                Description = $"{restaurant.Name} in {restaurant.Address} serving {restaurant.Category.Name} favorites.",
                BannerImageUrl = bannerImage,
                SearchTerm = search,
                SelectedCategory = category ?? "all",
                Categories = menuItems
                    .Select(item => item.Category)
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .OrderBy(name => name)
                    .Select(name => new MenuCategoryFilterViewModel { Value = name, Label = name })
                    .Prepend(new MenuCategoryFilterViewModel { Value = "all", Label = "All" })
                    .ToList(),
                MenuItems = menuItems
            };

            return View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(int menuItemId, int restaurantId)
        {
            var menuItem = await _context.MenuItem
                .AsNoTracking()
                .FirstOrDefaultAsync(item => item.Id == menuItemId && item.RestaurantId == restaurantId);

            if (menuItem == null)
            {
                return NotFound();
            }

            var cart = HttpContext.Session.GetJson<List<CartItemViewModel>>("cart") ?? new List<CartItemViewModel>();
            var existing = cart.FirstOrDefault(item => item.MenuItemId == menuItemId);

            if (existing == null)
            {
                cart.Add(new CartItemViewModel
                {
                    MenuItemId = menuItem.Id,
                    Name = menuItem.Name,
                    Image = menuItem.image,
                    UnitPrice = menuItem.Price,
                    Quantity = 1
                });
            }
            else
            {
                existing.Quantity += 1;
            }

            HttpContext.Session.SetJson("cart", cart);
            TempData["CartMessage"] = $"{menuItem.Name} added to cart.";

            return RedirectToAction(nameof(Menu), new { id = restaurantId });
        }

        private static string GetMenuCategory(string name, string description)
        {
            var text = $"{name} {description}".ToLowerInvariant();

            if (text.Contains("pizza") || text.Contains("margherita") || text.Contains("pepperoni"))
            {
                return "Pizza";
            }

            if (text.Contains("burger") || text.Contains("sandwich") || text.Contains("wrap"))
            {
                return "Sandwiches";
            }

            if (text.Contains("sushi") || text.Contains("sashimi") || text.Contains("ramen") || text.Contains("miso"))
            {
                return "Sushi";
            }

            if (text.Contains("salad"))
            {
                return "Salads";
            }

            if (text.Contains("drink") || text.Contains("pepsi") || text.Contains("shake") || text.Contains("lemonade") || text.Contains("latte"))
            {
                return "Drinks";
            }

            if (text.Contains("cake") || text.Contains("ice cream") || text.Contains("brownie") || text.Contains("pie"))
            {
                return "Desserts";
            }

            if (text.Contains("fries") || text.Contains("wings") || text.Contains("rings") || text.Contains("coleslaw") || text.Contains("bread") || text.Contains("soup"))
            {
                return "Sides";
            }

            return "Mains";
        }

        // GET: RestaurantController/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: RestaurantController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RestaurantFormViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            try
            {
                _repo.Create(vm);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(vm);
            }
        }

        // GET: RestaurantController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var vm = _repo.GetForEdit(id);
                return View(vm);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: RestaurantController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RestaurantFormViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            try
            {
                _repo.Update(vm);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(vm);
            }
        }

        // GET: RestaurantController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var restaurant = _repo.GetById(id);
                return View(restaurant);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: RestaurantController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _repo.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View();
            }
        }
    }
}
