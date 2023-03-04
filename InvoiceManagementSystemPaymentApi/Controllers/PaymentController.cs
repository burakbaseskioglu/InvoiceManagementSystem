using InvoiceManagementSystemPaymentApi.Business.Abstract;
using InvoiceManagementSystemPaymentApi.Entity;
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
        public IActionResult Index(Payment payment)
        {
            _paymentBusiness.Insert(payment);
            return Ok();
        }
    }
}
