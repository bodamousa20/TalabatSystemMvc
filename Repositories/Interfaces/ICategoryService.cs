using TalabatSmartVillage.Models;

namespace TalabatSmartVillage.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllAsync();
        Task<Category?> GetByIdWithRestaurantsAsync(int id);
        Task<Category?> GetByIdAsync(int id);
        Task<bool> CreateAsync(Category category);
        Task<bool> UpdateAsync(Category category);
        Task<bool> DeleteAsync(int id);
        bool Exists(int id);
    }
}
