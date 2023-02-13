using InvoiceManagementSystem.Business.Abstract;
using InvoiceManagementSystem.Core.Utilities.Security.JWT;
using InvoiceManagementSystem.Entity.Entities.Dto;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManagementSystem.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthBusiness _authBusiness;

        public AuthController(IAuthBusiness authBusiness)
        {
            _authBusiness = authBusiness;
        }

        [HttpPost("createToken")]
        public IActionResult CreateToken()
        {
            return Ok(_authBusiness.CreateToken());
        }

        [HttpPost("tokenControl")]
        public IActionResult TokenControl(string refreshToken)
        {
            return Ok(_authBusiness.TokenControl(refreshToken));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            return Ok(await _authBusiness.Login(userLoginDto));
        }
    }
}
