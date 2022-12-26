using InvoiceManagementSystem.Business.Abstract;
using InvoiceManagementSystem.Entity.Entities.Dto;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManagementSystem.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DuesController : Controller
    {
        private readonly IDuesBusiness _duesBusiness;

        public DuesController(IDuesBusiness duesBusiness)
        {
            _duesBusiness = duesBusiness;
        }

        [HttpPost("InsertRange")]
        public IActionResult InsertRange(InsertRangeDuesDto insertRangeDuesDto)
        {
            return Ok(_duesBusiness.InsertRange(insertRangeDuesDto));
        }
    }
}
