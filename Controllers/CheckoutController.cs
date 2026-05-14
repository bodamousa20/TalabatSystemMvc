using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TalabatSmartVillage.Extensions;
using TalabatSmartVillage.Services.Interfaces;
using TalabatSmartVillage.ViewModel.CartViewModels;
using TalabatSmartVillage.ViewModel.CheckoutViewModels;

namespace TalabatSmartVillage.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private readonly ICheckoutService _checkoutService;

        public CheckoutController(ICheckoutService checkoutService)
        {
            _checkoutService = checkoutService;
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

            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value!;
            var vm = await _checkoutService.BuildCheckoutViewModelAsync(userId, cart);

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

            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value!;
            var result = await _checkoutService.PlaceOrderAsync(userId, cart);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", result.ErrorMessage ?? "Something went wrong.");
                return View("Index", model);
            }

            HttpContext.Session.Remove("cart");

            TempData["OrderId"] = result.OrderId;
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
