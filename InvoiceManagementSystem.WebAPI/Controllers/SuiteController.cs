using InvoiceManagementSystem.Business.Abstract;
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
    }
}
