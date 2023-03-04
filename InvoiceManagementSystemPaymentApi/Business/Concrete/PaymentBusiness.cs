using InvoiceManagementSystemPaymentApi.Business.Abstract;
using InvoiceManagementSystemPaymentApi.Entity;
using InvoiceManagementSystemPaymentApi.Repository.Abstract;
using InvoiceManagementSystemPaymentApi.Subscriber;
using Newtonsoft.Json;

namespace InvoiceManagementSystemPaymentApi.Business.Concrete
{
    public class PaymentBusiness : IPaymentBusiness
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMessageSubscriber _messageSubscriber;

        public PaymentBusiness(IPaymentRepository paymentRepository, IMessageSubscriber messageSubscriber)
        {
            _paymentRepository = paymentRepository;
            _messageSubscriber = messageSubscriber;
        }

        public void Insert(Payment payment)
        {
            //_paymentRepository.InsertAsync(payment.Id.ToString(), payment);
            _messageSubscriber.ListenQueue("payment", (message) =>
            {
                var jsonString = JsonConvert.DeserializeObject<Payment>(message);
                _paymentRepository.InsertAsync(jsonString.Id.ToString(), jsonString);
            });
        }
    }
}
