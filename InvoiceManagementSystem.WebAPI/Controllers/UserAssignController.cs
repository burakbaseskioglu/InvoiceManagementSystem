using InvoiceManagementSystem.Business.Abstract;
using InvoiceManagementSystem.Core.Constant;
using InvoiceManagementSystem.Core.Utilities.Attribute;
using InvoiceManagementSystem.Entity.Entities.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManagementSystem.WebAPI.Controllers
{
    [ApiController]
    [Route("api/controller")]
    [AuthorizeRoles(RoleName.Management)]
    public class UserAssignController : Controller
    {
        private readonly IUserAssignBusiness _userAssignBusiness;

        public UserAssignController(IUserAssignBusiness userAssignBusiness)
        {
            _userAssignBusiness = userAssignBusiness;
        }

        [HttpGet("UserAssignList")]
        public IActionResult UserAssignCheckList()
        {
            return Ok(_userAssignBusiness.UserAssignChecklist());
        }

        [HttpPost("UserAssign")]
        public IActionResult UserAssign(UserAssignDto userAssignDto)
        {
            return Ok(_userAssignBusiness.UserAssign(userAssignDto));
        }

        [HttpPost("ManagementApprove")]
        public IActionResult UserAssignManagementApprove(UserAssignManagementDto userAssignManagementDto)
        {
            return Ok(_userAssignBusiness.UserAssignManagementApprove(userAssignManagementDto));
        }
    }
}
