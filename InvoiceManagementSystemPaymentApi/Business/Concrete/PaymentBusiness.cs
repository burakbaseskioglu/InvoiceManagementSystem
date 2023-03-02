using InvoiceManagementSystemPaymentApi.Business.Abstract;
using InvoiceManagementSystemPaymentApi.Entity;
using InvoiceManagementSystemPaymentApi.Repository.Abstract;

namespace InvoiceManagementSystemPaymentApi.Business.Concrete
{
    public class PaymentBusiness : IPaymentBusiness
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentBusiness(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public void Insert(Payment payment)
        {
            _paymentRepository.InsertAsync(payment);
        }
    }
}
