using Microsoft.EntityFrameworkCore;
using TalabatSmartVillage.Auth;
using TalabatSmartVillage.Models;
using TalabatSmartVillage.Services.Interfaces;

namespace TalabatSmartVillage.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllAsync()
            => await _context.category.ToListAsync();

        public async Task<Category?> GetByIdWithRestaurantsAsync(int id)
            => await _context.category
                .Include(c => c.Restaurants)
                .FirstOrDefaultAsync(c => c.Id == id);

        public async Task<Category?> GetByIdAsync(int id)
            => await _context.category.FindAsync(id);

        public async Task<bool> CreateAsync(Category category)
        {
            _context.Add(category);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Category category)
        {
            try
            {
                _context.Update(category);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return Exists(category.Id);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _context.category.FindAsync(id);
            if (category == null)
                return false;

            _context.category.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool Exists(int id)
            => _context.category.Any(e => e.Id == id);
    }
}
