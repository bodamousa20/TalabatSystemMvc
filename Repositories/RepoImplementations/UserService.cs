using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TalabatSmartVillage.Auth;
using TalabatSmartVillage.Models;
using TalabatSmartVillage.Services.Interfaces;
using TalabatSmartVillage.ViewModel.OrderViewModels;
using TalabatSmartVillage.ViewModel.UserViewModels;

namespace TalabatSmartVillage.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public UserService(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context     = context;
            _userManager = userManager;
        }

        public async Task<OrderHistoryViewModel> GetOrderHistoryAsync(string userId, int page)
        {
            const int pageSize = 5;

            var baseQuery = _context.Order
                .AsNoTracking()
                .Where(order => order.UserId == userId)
                .OrderByDescending(order => order.PlacedAt);

            var totalOrders = await baseQuery.CountAsync();
            var totalPages  = totalOrders == 0 ? 1 : (int)Math.Ceiling(totalOrders / (double)pageSize);
            var currentPage = Math.Clamp(page, 1, totalPages);

            var orders = await baseQuery
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .Select(order => new OrderSummaryViewModel
                {
                    Id              = order.Id,
                    PlacedAt        = order.PlacedAt,
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
                            Name      = item.menuItem.Name,
                            Quantity  = item.Quantity,
                            UnitPrice = item.UnitPrice
                        })
                        .ToList()
                })
                .ToListAsync();

            return new OrderHistoryViewModel
            {
                Orders      = orders,
                CurrentPage = currentPage,
                TotalPages  = totalPages,
                TotalOrders = totalOrders
            };
        }

        public async Task<UserProfileViewModel?> GetProfileAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return null;

            var roles = await _userManager.GetRolesAsync(user);

            return new UserProfileViewModel
            {
                FullName    = user.FullName,
                Email       = user.Email ?? string.Empty,
                PhoneNumber = user.PhoneNumber,
                Address     = user.Address,
                PostalCode  = user.postalcode,
                CreatedAt   = user.CreatedAt,
                Roles       = roles.Count == 0 ? "User" : string.Join(", ", roles)
            };
        }

        public async Task<UpdateProfileResult> UpdateProfileAsync(string userId, UserProfileViewModel model)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return new UpdateProfileResult { Succeeded = false, Errors = ["User not found."] };

            user.FullName    = model.FullName;
            user.PhoneNumber = model.PhoneNumber;
            user.Address     = model.Address ?? string.Empty;
            user.postalcode  = model.PostalCode ?? 0;

            var result = await _userManager.UpdateAsync(user);

            return new UpdateProfileResult
            {
                Succeeded = result.Succeeded,
                Errors    = result.Errors.Select(e => e.Description)
            };
        }
    }
}
