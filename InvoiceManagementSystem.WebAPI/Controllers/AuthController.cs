using InvoiceManagementSystem.Business.Abstract;
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
    }
}
