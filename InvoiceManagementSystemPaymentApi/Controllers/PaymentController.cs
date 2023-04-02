using InvoiceManagementSystemPaymentApi.Business.Abstract;
using InvoiceManagementSystemPaymentApi.Entity;
using InvoiceManagementSystemPaymentApi.Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManagementSystemPaymentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : Controller
    {
        private readonly IPaymentBusiness _paymentBusiness;

        public PaymentController(IPaymentBusiness paymentBusiness)
        {
            _paymentBusiness = paymentBusiness;
        }

        [HttpPost("insert")]
        public IActionResult Insert(Payment payment)
        {
            _paymentBusiness.Insert(payment);
            return Ok();
        }

        [HttpGet("getPay")]
        public IActionResult Get()
        {
            var data = _paymentBusiness.GetPay();
            return Ok(data);
        }

        [HttpPost("{billId}")]
        public IActionResult Pay(CardDto cardDto, int billId)
        {
            var result = _paymentBusiness.Pay(cardDto, billId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
