namespace TalabatSmartVillage.Repositories.Interfaces
{
    using TalabatSmartVillage.Models;
    using TalabatSmartVillage.ViewModel.AdminViewModels;

    public interface IAdminService
    {
        Task<AdminDashboardViewModel> GetDashboardAsync();
        Task<List<Order>> GetOrdersAsync();
        Task<bool> UpdateOrderStatusAsync(int orderId, OrderStatus status);
    }
}
