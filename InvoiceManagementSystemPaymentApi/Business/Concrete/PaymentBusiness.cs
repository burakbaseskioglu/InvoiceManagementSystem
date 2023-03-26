using InvoiceManagementSystemPaymentApi.Business.Abstract;
using InvoiceManagementSystemPaymentApi.Entity;
using InvoiceManagementSystemPaymentApi.Entity.Dto;
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

        public Payment GetPay()
        {
            return _paymentRepository.GetAll().SingleOrDefault();
        }

        public void Insert(Payment payment)
        {
            //_messageSubscriber.ListenQueue("payment", (message) =>
            //{
            //    var jsonString = JsonConvert.DeserializeObject<Payment>(message);
            //    _paymentRepository.InsertAsync(jsonString!.Id.ToString(), jsonString);
            //});

            _paymentRepository.InsertAsync(payment.Id.ToString(), payment);
        }

        public bool Pay(CardDto cardDto)
        {
            throw new NotImplementedException();
        }
    }
}
