using InvoiceManagementSystem.Business.Abstract;
using InvoiceManagementSystem.Core.Constant;
using InvoiceManagementSystem.Core.Utilities.Attribute;
using InvoiceManagementSystem.Entity.Entities.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManagementSystem.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AuthorizeRoles(RoleName.Management, RoleName.User)]
    public class SuiteController : Controller
    {
        private readonly ISuiteBusiness _suiteBusiness;

        public SuiteController(ISuiteBusiness suiteBusiness)
        {
            _suiteBusiness = suiteBusiness;
        }

        [HttpPost("InsertSuite")]
        public IActionResult Insert(CreateSuiteDto createSuiteDto)
        {
            return Ok(_suiteBusiness.Insert(createSuiteDto));
        }

        [HttpGet("GetAllSuitesWithUsers")]
        public IActionResult GetAll()
        {
            return Ok(_suiteBusiness.GetAll());
        }

        [HttpPut("UpdateSuite")]
        public IActionResult Update(UpdateSuiteDto updateSuiteDto)
        {
            return Ok(_suiteBusiness.Update(updateSuiteDto));
        }

        [HttpDelete("DeleteSuite")]
        public IActionResult Delete(int suiteId)
        {
            return Ok(_suiteBusiness.Delete(suiteId));
        }
    }
}
