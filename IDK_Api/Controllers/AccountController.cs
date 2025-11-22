using BusinessLogic.DTOs.Account;
using BusinessLogic.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IDK_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IAccountService _accountService;
        private string? CurrentIp => HttpContext.Connection.RemoteIpAddress?.ToString();
        public AccountController(IAccountService accountService)
        {
            _accountService  = accountService;
        }

        [HttpPost("register")]

        public async Task<IActionResult> Register(RegisterModel model)
        {
            await _accountService.Register(model);
            return Ok();
        }
        [HttpPost("login")]

        public async Task<IActionResult> Login(LoginModel model)
        {
            var res = await _accountService.Login(model, CurrentIp);

            return Ok(res);
        }
        [HttpPost("logout")]

        public async Task<IActionResult> Logout(LogoutModel model)
        {
            await _accountService.Logout(model);

            return Ok();
        }

        [HttpPost("Refresh")]

        public async Task<IActionResult> RefreshToken(string token)
        {
            var res = await _accountService.Refresh(token, CurrentIp);


            return Ok(res);
        }
    }
}
