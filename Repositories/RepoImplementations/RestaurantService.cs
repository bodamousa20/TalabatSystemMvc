using Microsoft.EntityFrameworkCore;
using TalabatSmartVillage.Auth;
using TalabatSmartVillage.Models;
using TalabatSmartVillage.Repositories.Interfaces;
using TalabatSmartVillage.Services.Interfaces;
using TalabatSmartVillage.ViewModel.CartViewModels;
using TalabatSmartVillage.ViewModel.MenuItemViewModels;
using TalabatSmartVillage.ViewModel.RestaurantViewModels;

namespace TalabatSmartVillage.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly AppDbContext _context;
        private readonly IRestaurantRepo _repo;

        public RestaurantService(AppDbContext context, IRestaurantRepo repo)
        {
            _context = context;
            _repo    = repo;
        }

        // ── Menu ────────────────────────────────────────────────────────────

        public async Task<RestaurantMenuViewModel?> GetMenuAsync(int restaurantId, string? search, string? category)
        {
            var restaurant = await _context.restaurant
                .AsNoTracking()
                .Include(r => r.Category)
                .FirstOrDefaultAsync(r => r.Id == restaurantId);

            if (restaurant == null)
                return null;

            var menuQuery = _context.MenuItem
                .AsNoTracking()
                .Where(item => item.RestaurantId == restaurantId);

            if (!string.IsNullOrWhiteSpace(search))
                menuQuery = menuQuery.Where(item =>
                    item.Name.Contains(search) || item.Description.Contains(search));

            if (!string.IsNullOrWhiteSpace(category) &&
                !string.Equals(category, "all", StringComparison.OrdinalIgnoreCase))
            {
                if (string.Equals(category, "available", StringComparison.OrdinalIgnoreCase))
                    menuQuery = menuQuery.Where(item => item.IsAvailable);
                else if (string.Equals(category, "unavailable", StringComparison.OrdinalIgnoreCase))
                    menuQuery = menuQuery.Where(item => !item.IsAvailable);
            }

            var menuItems = await menuQuery
                .OrderBy(item => item.Name)
                .Select(item => new MenuItemCardViewModel
                {
                    Id           = item.Id,
                    Name         = item.Name,
                    Description  = item.Description,
                    Price        = item.Price,
                    IsAvailable  = item.IsAvailable,
                    Image        = item.image,
                    RestaurantId = restaurantId,
                    Category     = string.Empty
                })
                .ToListAsync();

            foreach (var item in menuItems)
                item.Category = GetMenuCategory(item.Name, item.Description);

            if (!string.IsNullOrWhiteSpace(category) &&
                !string.Equals(category, "all", StringComparison.OrdinalIgnoreCase))
            {
                menuItems = menuItems
                    .Where(item => string.Equals(item.Category, category, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            var bannerImage = await _context.MenuItem
                .AsNoTracking()
                .Where(item => item.RestaurantId == restaurantId && item.image != null)
                .Select(item => item.image)
                .FirstOrDefaultAsync();

            return new RestaurantMenuViewModel
            {
                Id               = restaurant.Id,
                Name             = restaurant.Name,
                CategoryName     = restaurant.Category.Name,
                Address          = restaurant.Address,
                IsOpen           = restaurant.IsOpen,
                Description      = $"{restaurant.Name} in {restaurant.Address} serving {restaurant.Category.Name} favorites.",
                BannerImageUrl   = bannerImage,
                SearchTerm       = search,
                SelectedCategory = category ?? "all",
                Categories       = menuItems
                    .Select(item => item.Category)
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .OrderBy(name => name)
                    .Select(name => new MenuCategoryFilterViewModel { Value = name, Label = name })
                    .Prepend(new MenuCategoryFilterViewModel { Value = "all", Label = "All" })
                    .ToList(),
                MenuItems = menuItems
            };
        }

        // ── Cart ────────────────────────────────────────────────────────────

        public async Task<AddToCartResult> AddToCartAsync(int menuItemId, int restaurantId, List<CartItemViewModel> cart)
        {
            var menuItem = await _context.MenuItem
                .AsNoTracking()
                .FirstOrDefaultAsync(item => item.Id == menuItemId && item.RestaurantId == restaurantId);

            if (menuItem == null)
                return new AddToCartResult { Succeeded = false, ErrorMessage = "Item not found." };

            var existing = cart.FirstOrDefault(item => item.MenuItemId == menuItemId);
            if (existing == null)
            {
                cart.Add(new CartItemViewModel
                {
                    MenuItemId = menuItem.Id,
                    Name       = menuItem.Name,
                    Image      = menuItem.image,
                    UnitPrice  = menuItem.Price,
                    Quantity   = 1
                });
            }
            else
            {
                existing.Quantity += 1;
            }

            return new AddToCartResult
            {
                Succeeded = true,
                ItemName  = menuItem.Name,
                Cart      = cart
            };
        }


        public IEnumerable<RestaurantListViewModel> GetAll()     => _repo.GetAll();
        public RestaurantDetailsViewModel GetById(int id)        => _repo.GetById(id);
        public RestaurantFormViewModel GetForEdit(int id)        => _repo.GetForEdit(id);
        public void Create(RestaurantFormViewModel vm)           => _repo.Create(vm);
        public void Update(RestaurantFormViewModel vm)           => _repo.Update(vm);
        public void Delete(int id)                               => _repo.Delete(id);


        private static string GetMenuCategory(string name, string description)
        {
            var text = $"{name} {description}".ToLowerInvariant();

            if (text.Contains("pizza") || text.Contains("margherita") || text.Contains("pepperoni"))
                return "Pizza";
            if (text.Contains("burger") || text.Contains("sandwich") || text.Contains("wrap"))
                return "Sandwiches";
            if (text.Contains("sushi") || text.Contains("sashimi") || text.Contains("ramen") || text.Contains("miso"))
                return "Sushi";
            if (text.Contains("salad"))
                return "Salads";
            if (text.Contains("drink") || text.Contains("pepsi") || text.Contains("shake") || text.Contains("lemonade") || text.Contains("latte"))
                return "Drinks";
            if (text.Contains("cake") || text.Contains("ice cream") || text.Contains("brownie") || text.Contains("pie"))
                return "Desserts";
            if (text.Contains("fries") || text.Contains("wings") || text.Contains("rings") || text.Contains("coleslaw") || text.Contains("bread") || text.Contains("soup"))
                return "Sides";

            return "Mains";
        }

        IEnumerable<RestaurantMenuViewModel> IRestaurantService.GetAll()
        {
            throw new NotImplementedException();
        }

        RestaurantMenuViewModel IRestaurantService.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
