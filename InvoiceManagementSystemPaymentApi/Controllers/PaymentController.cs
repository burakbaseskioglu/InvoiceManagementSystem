using InvoiceManagementSystemPaymentApi.Business.Abstract;
using InvoiceManagementSystemPaymentApi.Entity;
using InvoiceManagementSystemPaymentApi.Entity.Dto;
using InvoiceManagementSystemPaymentApi.Utilities.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManagementSystemPaymentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AuthorizeRoles("User")]
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
            var result = _paymentBusiness.Insert(payment);
            return Ok(result);
        }

        [HttpPost("pay/{billId}")]
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
