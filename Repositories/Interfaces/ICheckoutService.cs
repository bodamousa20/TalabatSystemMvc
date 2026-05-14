using TalabatSmartVillage.Models;
using TalabatSmartVillage.ViewModel.CartViewModels;
using TalabatSmartVillage.ViewModel.CheckoutViewModels;

namespace TalabatSmartVillage.Services.Interfaces
{
    public interface ICheckoutService
    {
        Task<CheckoutViewModel> BuildCheckoutViewModelAsync(string userId, List<CartItemViewModel> cart);
        Task<PlaceOrderResult> PlaceOrderAsync(string userId, List<CartItemViewModel> cart);
    }

    public class PlaceOrderResult
    {
        public bool Succeeded { get; set; }
        public int OrderId { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
