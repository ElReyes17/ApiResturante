using ApiRestaurante.Core.Application.Dtos.Account;
using System.Threading.Tasks;

namespace ApiRestaurante.Core.Application.Interfaces.Services
{
    public interface IAccountService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<string> ConfirmAccountAsync(string userId, string token);
        Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordRequest request, string origin);
        Task<RegisterResponse> RegisterBasicUserAsync(RegisterRequest request, string origin, string Role);
        Task<ResetPasswordResponse> ResetPasswordAsync(ResetPasswordRequest request);
        Task SignOutAsync();
    }
}