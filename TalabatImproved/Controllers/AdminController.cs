using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TalabatSmartVillage.Auth;
using TalabatSmartVillage.Models;
using TalabatSmartVillage.ViewModel.AdminViewModels;

namespace TalabatSmartVillage.Controllers
{
    [Authorize(Roles = AppRoles.ADMIN)]
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public AdminController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            var model = new AdminDashboardViewModel
            {
                RestaurantCount = await _context.restaurant.CountAsync(),
                CategoryCount = await _context.category.CountAsync(),
                MenuItemCount = await _context.MenuItem.CountAsync(),
                OrderCount = await _context.Order.CountAsync(),
                UserCount = await _userManager.Users.CountAsync(),
                PendingOrderCount = await _context.Order.CountAsync(o => o.Status == OrderStatus.PENDING),
                TotalRevenue = await _context.Order
                    .Where(o => o.Status == OrderStatus.DELIVERED)
                    .SumAsync(o => (decimal?)o.TotalOrderPrice) ?? 0
            };

            return View(model);
        }

        // GET: Admin order management
        [HttpGet]
        public async Task<IActionResult> Orders()
        {
            var orders = await _context.Order
                .AsNoTracking()
                .Include(o => o.User)
                .Include(o => o.Restaurant)
                .OrderByDescending(o => o.PlacedAt)
                .ToListAsync();

            return View(orders);
        }

        // POST: Update order status
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateOrderStatus(int orderId, OrderStatus status)
        {
            var order = await _context.Order.FindAsync(orderId);
            if (order == null)
                return NotFound();

            order.Status = status;
            await _context.SaveChangesAsync();

            TempData["Success"] = $"Order #{orderId} status updated.";
            return RedirectToAction(nameof(Orders));
        }
    }
}
