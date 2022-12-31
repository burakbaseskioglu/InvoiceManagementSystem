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

        [HttpGet("PaidDebtList")]
        public IActionResult PaidDebtList() 
        {
            return Ok(_duesBusiness.PaidDebtList());
        }

        [HttpGet("UnpaidDebtList")]
        public IActionResult UnpaidDebtList()
        {
            return Ok(_duesBusiness.UnpaidDebtList());
        }

        [HttpGet("GetAllDues")]
        public IActionResult GetAll()
        {
            return Ok(_duesBusiness.GetAll());
        }

        [HttpPut("UpdateDues")]
        public IActionResult Update(InsertDuesDto insertDuesDto) 
        {
            return Ok(_duesBusiness.Update(insertDuesDto));
        }

        [HttpDelete("DeleteDues")]
        public IActionResult Delete(int duesId)
        {
            return Ok(_duesBusiness.Delete(duesId));
        }
    }
}
