using InvoiceManagementSystem.Business.Abstract;
using InvoiceManagementSystem.Entity.Entities.Dto;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManagementSystem.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuiteController : Controller
    {
        private readonly ISuiteBusiness _suiteBusiness;

        public SuiteController(ISuiteBusiness suiteBusiness)
        {
            _suiteBusiness = suiteBusiness;
        }

        [HttpPost("CreateMultipleSuite")]
        public IActionResult CreateSuiteRange()
        {
            return Ok();
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
    }
}
