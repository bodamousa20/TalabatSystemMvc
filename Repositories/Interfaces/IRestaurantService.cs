using TalabatSmartVillage.Models;
using TalabatSmartVillage.ViewModel.CartViewModels;
using TalabatSmartVillage.ViewModel.MenuItemViewModels;
using TalabatSmartVillage.ViewModel.RestaurantViewModels;

namespace TalabatSmartVillage.Services.Interfaces
{
    public interface IRestaurantService
    {
        // Menu
        Task<RestaurantMenuViewModel?> GetMenuAsync(int restaurantId, string? search, string? category);

        // Cart
        Task<AddToCartResult> AddToCartAsync(int menuItemId, int restaurantId, List<CartItemViewModel> cart);

        // CRUD (Admin)
        IEnumerable<RestaurantMenuViewModel> GetAll();
        RestaurantMenuViewModel GetById(int id);
        RestaurantFormViewModel GetForEdit(int id);
        void Create(RestaurantFormViewModel vm);
        void Update(RestaurantFormViewModel vm);
        void Delete(int id);
    }

    public class AddToCartResult
    {
        public bool Succeeded { get; set; }
        public string? ItemName { get; set; }
        public string? ErrorMessage { get; set; }
        public List<CartItemViewModel> Cart { get; set; } = [];
    }
}
