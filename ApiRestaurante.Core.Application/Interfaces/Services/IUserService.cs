using ApiRestaurante.Core.Application.Dtos.Account;
using ApiRestaurante.Core.Application.ViewModels.User;
using System.Threading.Tasks;

namespace ApiRestaurante.Core.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<string> ConfirmEmailAsync(string userId, string token);
        Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordViewModel vm, string origin);
        Task<AuthenticationResponse> LoginAsync(LoginViewModel vm);
        Task<RegisterResponse> RegisterAsync(SaveUserViewModel vm, string origin, string Role);
        Task<ResetPasswordResponse> ResetPasswordAsync(ResetPasswordViewModel vm);
        Task SignOutAsync();
    }
}