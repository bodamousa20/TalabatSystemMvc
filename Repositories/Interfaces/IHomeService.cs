using TalabatSmartVillage.Models;

namespace TalabatSmartVillage.Services.Interfaces
{
    public interface IHomeService
    {
        Task<List<Category>> GetCategoriesAsync();
        Task<List<Restaurant>> GetRestaurantsAsync();
    }
}
