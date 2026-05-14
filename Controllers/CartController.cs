using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TalabatSmartVillage.Extensions;
using TalabatSmartVillage.ViewModel.CartViewModels;

namespace TalabatSmartVillage.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        // GET: /Cart
        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetJson<List<CartItemViewModel>>("cart") ?? new();
            return View(cart);


        }

        // POST: /Cart/UpdateQuantity
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateQuantity(int menuItemId, int quantity)
        {
            var cart = HttpContext.Session.GetJson<List<CartItemViewModel>>("cart") ?? new();
            var item = cart.FirstOrDefault(x => x.MenuItemId == menuItemId);

            if (item != null)
            {
                if (quantity <= 0)
                    cart.Remove(item);
                else
                    item.Quantity = quantity;
            }

            HttpContext.Session.SetJson("cart", cart);
            return RedirectToAction(nameof(Index));
        }

        // POST: /Cart/Remove
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(int menuItemId)
        {
            var cart = HttpContext.Session.GetJson<List<CartItemViewModel>>("cart") ?? new();
            cart.RemoveAll(x => x.MenuItemId == menuItemId);
            HttpContext.Session.SetJson("cart", cart);
            TempData["CartMessage"] = "Item removed from cart.";
            return RedirectToAction(nameof(Index));
        }

        // POST: /Cart/Clear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Clear()
        {
            HttpContext.Session.Remove("cart");
            return RedirectToAction(nameof(Index));
        }
    }
}
