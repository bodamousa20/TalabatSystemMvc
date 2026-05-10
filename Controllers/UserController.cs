using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TalabatSmartVillage.Auth;
using TalabatSmartVillage.Models;
using TalabatSmartVillage.ViewModel.OrderViewModels;
using TalabatSmartVillage.ViewModel.UserViewModels;

namespace TalabatSmartVillage.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public UserController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1)
        {
            const int pageSize = 5;
            var userId = _userManager.GetUserId(User);

            if (string.IsNullOrWhiteSpace(userId))
            {
                return Challenge();
            }

            var baseQuery = _context.Order
                .AsNoTracking()
                .Where(order => order.UserId == userId)
                .OrderByDescending(order => order.PlacedAt);

            var totalOrders = await baseQuery.CountAsync();
            var totalPages = totalOrders == 0 ? 1 : (int)Math.Ceiling(totalOrders / (double)pageSize);
            var currentPage = Math.Clamp(page, 1, totalPages);

            var orders = await baseQuery
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .Select(order => new OrderSummaryViewModel
                {
                    Id = order.Id,
                    PlacedAt = order.PlacedAt,
                    TotalOrderPrice = order.TotalOrderPrice,
                    Status = order.Status == OrderStatus.DELIVERED
                        ? "Delivered"
                        : order.Status == OrderStatus.CANCELLED
                            ? "Cancelled"
                            : order.Status == OrderStatus.CONFIRMED
                                ? "Preparing"
                                : "Pending",
                    StatusBadgeClass = order.Status == OrderStatus.DELIVERED
                        ? "bg-success"
                        : order.Status == OrderStatus.CANCELLED
                            ? "bg-danger"
                            : order.Status == OrderStatus.CONFIRMED
                                ? "bg-info text-white"
                                : "bg-warning text-dark",
                    Items = order.OrderItems
                        .Select(item => new OrderItemViewModel
                        {
                            Name = item.menuItem.Name,
                            Quantity = item.Quantity,
                            UnitPrice = item.UnitPrice
                        })
                        .ToList()
                })
                .ToListAsync();

            var model = new OrderHistoryViewModel
            {
                Orders = orders,
                CurrentPage = currentPage,
                TotalPages = totalPages,
                TotalOrders = totalOrders
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Challenge();
            }

            var roles = await _userManager.GetRolesAsync(user);

            var model = new UserProfileViewModel
            {
                FullName = user.FullName,
                Email = user.Email ?? string.Empty,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                PostalCode = user.postalcode,
                CreatedAt = user.CreatedAt,
                Roles = roles.Count == 0 ? "User" : string.Join(", ", roles)
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Profile(UserProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Challenge();
            }

            user.FullName = model.FullName;
            user.PhoneNumber = model.PhoneNumber;
            user.Address = model.Address ?? string.Empty;
            user.postalcode = model.PostalCode ?? 0;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(model);
            }

            var roles = await _userManager.GetRolesAsync(user);
            model.Email = user.Email ?? string.Empty;
            model.CreatedAt = user.CreatedAt;
            model.Roles = roles.Count == 0 ? "User" : string.Join(", ", roles);

            ViewData["StatusMessage"] = "Profile updated successfully.";
            return View(model);
        }
    }
}
