using Microsoft.AspNetCore.Identity;
using TalabatSmartVillage.Auth;
using TalabatSmartVillage.Models;
using TalabatSmartVillage.Services.Interfaces;
using TalabatSmartVillage.ViewModel.CartViewModels;
using TalabatSmartVillage.ViewModel.CheckoutViewModels;

namespace TalabatSmartVillage.Services
{
    public class CheckoutService : ICheckoutService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public CheckoutService(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<CheckoutViewModel> BuildCheckoutViewModelAsync(string userId, List<CartItemViewModel> cart)
        {
            var user = await _userManager.FindByIdAsync(userId);

            return new CheckoutViewModel
            {
                FullName  = user?.FullName ?? string.Empty,
                Phone     = user?.PhoneNumber ?? string.Empty,
                Address   = user?.Address ?? string.Empty,
                CartItems = cart
            };
        }

        public async Task<PlaceOrderResult> PlaceOrderAsync(string userId, List<CartItemViewModel> cart)
        {
            var firstItem = await _context.MenuItem.FindAsync(cart[0].MenuItemId);
            if (firstItem == null)
            {
                return new PlaceOrderResult
                {
                    Succeeded    = false,
                    ErrorMessage = "One or more items are no longer available."
                };
            }

            var order = new Order
            {
                UserId          = userId,
                RestaurantId    = firstItem.RestaurantId,
                Status          = OrderStatus.PENDING,
                TotalOrderPrice = cart.Sum(x => x.LineTotal),
                PlacedAt        = DateTime.UtcNow
            };

            foreach (var cartItem in cart)
            {
                order.OrderItems.Add(new OrderItem
                {
                    MenuItemId = cartItem.MenuItemId,
                    Quantity   = cartItem.Quantity,
                    UnitPrice  = cartItem.UnitPrice
                });
            }

            _context.Order.Add(order);
            await _context.SaveChangesAsync();

            return new PlaceOrderResult
            {
                Succeeded = true,
                OrderId   = order.Id
            };
        }
    }
}
