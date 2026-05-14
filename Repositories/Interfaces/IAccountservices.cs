using TalabatSmartVillage.Controllers;
using TalabatSmartVillage.ViewModel.AccountViewModel;

namespace TalabatSmartVillage.Repositories.Interfaces
{
    public interface IAccountservices
    {
        Task<bool> IsEmailTakenAsync(string email);
        Task<RegisterResult> RegisterAsync(RegisterViewModel model);
        Task<LoginResult> LoginAsync(LoginViewModel model);
        Task LogoutAsync();

    }
}
