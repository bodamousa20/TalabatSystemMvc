using TalabatSmartVillage.ViewModel.OrderViewModels;
using TalabatSmartVillage.ViewModel.UserViewModels;

namespace TalabatSmartVillage.Services.Interfaces
{
    public interface IUserService
    {
        Task<OrderHistoryViewModel> GetOrderHistoryAsync(string userId, int page);
        Task<UserProfileViewModel?> GetProfileAsync(string userId);
        Task<UpdateProfileResult> UpdateProfileAsync(string userId, UserProfileViewModel model);
    }

    public class UpdateProfileResult
    {
        public bool Succeeded { get; set; }
        public IEnumerable<string> Errors { get; set; } = [];
    }
}
