using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TalabatSmartVillage.Auth;
using TalabatSmartVillage.Extensions;
using TalabatSmartVillage.Models;
using TalabatSmartVillage.ViewModel.CartViewModels;
using TalabatSmartVillage.ViewModel.CheckoutViewModels;

namespace TalabatSmartVillage.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public CheckoutController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: /Checkout
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var cart = HttpContext.Session.GetJson<List<CartItemViewModel>>("cart");

            if (cart == null || !cart.Any())
            {
                TempData["Error"] = "Your cart is empty.";
                return RedirectToAction("Index", "Cart");
            }

            var user = await _userManager.GetUserAsync(User);

            var vm = new CheckoutViewModel
            {
                FullName = user?.FullName ?? string.Empty,
                Phone = user?.PhoneNumber ?? string.Empty,
                Address = user?.Address ?? string.Empty,
                CartItems = cart
            };

            return View(vm);
        }

        // POST: /Checkout/PlaceOrder
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PlaceOrder(CheckoutViewModel model)
        {
            var cart = HttpContext.Session.GetJson<List<CartItemViewModel>>("cart");

            if (cart == null || !cart.Any())
            {
                TempData["Error"] = "Your cart is empty.";
                return RedirectToAction("Index", "Cart");
            }

            model.CartItems = cart;

            if (!ModelState.IsValid)
                return View("Index", model);

            // Determine restaurant from first item's restaurant
            // (cart is per-restaurant in this system)
            var firstItem = await _context.MenuItem.FindAsync(cart[0].MenuItemId);
            if (firstItem == null)
            {
                ModelState.AddModelError("", "One or more items are no longer available.");
                return View("Index", model);
            }

            var userId = _userManager.GetUserId(User);

            // Create Order
            var order = new Order
            {
                UserId = userId!,
                RestaurantId = firstItem.RestaurantId,
                Status = OrderStatus.PENDING,
                TotalOrderPrice = cart.Sum(x => x.LineTotal),
                PlacedAt = DateTime.UtcNow
            };

            // Create OrderItems
            foreach (var cartItem in cart)
            {
                order.OrderItems.Add(new OrderItem
                {
                    MenuItemId = cartItem.MenuItemId,
                    Quantity = cartItem.Quantity,
                    UnitPrice = cartItem.UnitPrice
                });
            }

            _context.Order.Add(order);
            await _context.SaveChangesAsync();

            // Clear cart after successful order
            HttpContext.Session.Remove("cart");

            TempData["OrderId"] = order.Id;
            return RedirectToAction("Confirmation");
        }

        // GET: /Checkout/Confirmation
        [HttpGet]
        public IActionResult Confirmation()
        {
            var orderId = TempData["OrderId"];
            if (orderId == null)
                return RedirectToAction("Index", "Home");

            ViewBag.OrderId = orderId;
            return View();
        }
    }
}
