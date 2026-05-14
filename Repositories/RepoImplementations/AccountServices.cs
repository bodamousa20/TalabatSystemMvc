using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using System.Security.Claims;
using TalabatSmartVillage.Auth;
using TalabatSmartVillage.Controllers;
using TalabatSmartVillage.Repositories.Interfaces;
using TalabatSmartVillage.ViewModel.AccountViewModel;

namespace TalabatSmartVillage.Services
{
    public class AccountService : IAccountservices
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> IsEmailTakenAsync(string email)
            => await _userManager.FindByEmailAsync(email) != null;

        public async Task<RegisterResult> RegisterAsync(RegisterViewModel model)
        {
            var newUser = new AppUser
            {
                FullName = model.FullName,
                Email = model.Email,
                UserName = model.Email,
                PhoneNumber = model.Phone,
                Address = model.Address,
                postalcode = model.PostalCode,
                CreatedAt = DateTime.UtcNow
            };

            var result = await _userManager.CreateAsync(newUser, model.Password);

            if (result.Succeeded)
                await _userManager.AddToRoleAsync(newUser, AppRoles.USER);

            return new RegisterResult
            {
                Succeeded = result.Succeeded,
                Errors = result.Errors.Select(e => e.Description)
            };
        }

        public async Task<LoginResult> LoginAsync(LoginViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return new LoginResult { Succeeded = false };

            var result = await _signInManager.PasswordSignInAsync(
                user, model.Password, model.RememberMe, lockoutOnFailure: false);

            if (!result.Succeeded)
                return new LoginResult { Succeeded = false };

            var roles = await _userManager.GetRolesAsync(user);
            return new LoginResult
            {
                Succeeded = true,
                IsAdmin = roles.Contains(AppRoles.ADMIN)
            };
        }

        public async Task LogoutAsync()
            => await _signInManager.SignOutAsync();


        public AuthenticationProperties GetGoogleLoginProperties(string redirectUrl)
        {
            return _signInManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl);
        }

        public async Task<SignInResult> GoogleLoginAsync()
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null) return SignInResult.Failed;

            // Try sign in if user already linked Google before
            var result = await _signInManager.ExternalLoginSignInAsync(
                info.LoginProvider, info.ProviderKey, isPersistent: false);

            return result;
        }

        public async Task<IdentityResult> RegisterExternalAsync(ExternalLoginInfo info)
        {
            var email = info.Principal.FindFirstValue(ClaimTypes.Email);
            var name = info.Principal.FindFirstValue(ClaimTypes.Name);

            var user = new AppUser
            {
                UserName = email,
                Email = email,
                FullName = name,  // adjust to match your User model
                CreatedAt = DateTime.UtcNow
            };

            var result = await _userManager.CreateAsync(user);
            if (result.Succeeded)
                await _userManager.AddLoginAsync(user, info);

            return result;
        }
    }
}