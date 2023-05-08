using InvoiceManagementSystem.Business.Abstract;
using InvoiceManagementSystem.Core.Utilities.Security.JWT;
using InvoiceManagementSystem.Entity.Entities.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManagementSystem.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly IAuthBusiness _authBusiness;

        public AuthController(IAuthBusiness authBusiness)
        {
            _authBusiness = authBusiness;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
        {
            return Ok(await _authBusiness.Register(userRegisterDto));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            return Ok(await _authBusiness.Login(userLoginDto));
        }

        [HttpPost("verifyRefreshToken")]
        public async Task<IActionResult> TryToLogin(string refreshToken)
        {
            return Ok(await _authBusiness.TokenControl(refreshToken));
        }
    }
}
