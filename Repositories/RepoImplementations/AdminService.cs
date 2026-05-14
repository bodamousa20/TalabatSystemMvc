using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TalabatSmartVillage.Auth;
using TalabatSmartVillage.Models;
using TalabatSmartVillage.Repositories.Interfaces;
using TalabatSmartVillage.ViewModel.AdminViewModels;

public class AdminService : IAdminService
{
    private readonly AppDbContext _context;
    private readonly UserManager<AppUser> _userManager;

    public AdminService(AppDbContext context, UserManager<AppUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<AdminDashboardViewModel> GetDashboardAsync()
    {
        return new AdminDashboardViewModel
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
    }

    public async Task<List<Order>> GetOrdersAsync()
    {
        return await _context.Order
            .AsNoTracking()
            .Include(o => o.User)
            .Include(o => o.Restaurant)
            .OrderByDescending(o => o.PlacedAt)
            .ToListAsync();
    }

    public async Task<bool> UpdateOrderStatusAsync(int orderId, OrderStatus status)
    {
        var order = await _context.Order.FindAsync(orderId);
        if (order == null)
            return false;

        order.Status = status;
        await _context.SaveChangesAsync();
        return true;
    }
}