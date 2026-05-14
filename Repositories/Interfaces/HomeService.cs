using Microsoft.EntityFrameworkCore;
using TalabatSmartVillage.Auth;
using TalabatSmartVillage.Models;
using TalabatSmartVillage.Services.Interfaces;

namespace TalabatSmartVillage.Services
{
    public class HomeService : IHomeService
    {
        private readonly AppDbContext _context;

        public HomeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetCategoriesAsync()
            => await _context.category.ToListAsync();

        public async Task<List<Restaurant>> GetRestaurantsAsync()
            => await _context.restaurant.ToListAsync();
    }
}
