using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiRestaurante.Core.Application.Dtos.Account;
using ApiRestaurante.Core.Application.Interfaces.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace ApiRestaurante.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticationRequest request)
        {
            return Ok(await _accountService.AuthenticateAsync(request));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("register-admin")]
        public async Task<IActionResult> RegisterAdminAsync(RegisterRequest request)
        {
            var origin = Request.Headers["origin"];
            return Ok(await _accountService.RegisterBasicUserAsync(request, origin, "Admin"));
        }
       
        [HttpPost("register-mesero")]
        public async Task<IActionResult> RegisterMeseroAsync(RegisterRequest request)
        {
            var origin = Request.Headers["origin"];
            return Ok(await _accountService.RegisterBasicUserAsync(request, origin, "Mesero"));
        }


        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPasswordAsync(ForgotPasswordRequest request)
        {
            var origin = Request.Headers["origin"];
            return Ok(await _accountService.ForgotPasswordAsync(request, origin));
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPasswordAsync(ResetPasswordRequest request)
        {           
            return Ok(await _accountService.ResetPasswordAsync(request));
        }
    }
}
