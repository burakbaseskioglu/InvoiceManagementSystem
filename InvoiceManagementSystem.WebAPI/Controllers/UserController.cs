using InvoiceManagementSystem.Business.Abstract;
using InvoiceManagementSystem.Business.Concrete;
using InvoiceManagementSystem.Core.Utilities.Security.Hashing;
using InvoiceManagementSystem.Entity.Entities.Dto;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManagementSystem.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserBusiness _userBusiness;

        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [HttpGet("GetUsers")]
        public IActionResult GetApartments()
        {
            return Ok(_userBusiness.GetAll());
        }

        [HttpGet("GetUserById")]
        public IActionResult GetApartmentById(int userId)
        {
            return Ok(_userBusiness.GetById(userId));
        }

        [HttpPost("InsertUser")]
        public async Task<IActionResult> Insert(UserInsertDto userInsertDto)
        {
            return Ok(await _userBusiness.Insert(userInsertDto));
        }

        [HttpPut("UpdateUser")]
        public IActionResult Update(UserInsertDto userInsertDto)
        {
            return Ok(_userBusiness.Update(userInsertDto));
        }

        [HttpDelete("DeleteUser")]
        public IActionResult Delete(int userId)
        {
            return Ok(_userBusiness.Delete(userId));
        }
    }
}
