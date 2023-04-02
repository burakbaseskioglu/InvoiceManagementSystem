using InvoiceManagementSystemPaymentApi.Business.Abstract;
using InvoiceManagementSystemPaymentApi.Entity;
using InvoiceManagementSystemPaymentApi.Entity.Dto;
using InvoiceManagementSystemPaymentApi.Repository.Abstract;

namespace InvoiceManagementSystemPaymentApi.Business.Concrete
{
    public class PaymentBusiness : IPaymentBusiness
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly ICardRepository _cardRepository;

        public PaymentBusiness(IPaymentRepository paymentRepository, ICardRepository cardRepository)
        {
            _paymentRepository = paymentRepository;
            _cardRepository = cardRepository;
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
            var card = _cardRepository.Get(x => x.CardOwner.ToLower() == cardDto.CardOwner.ToLower() &&
                x.CardNumber == cardDto.CardNumber &&
                x.CvcCode == cardDto.CvcCode &&
                x.ExpireMonth == cardDto.ExpireMonth &&
                x.ExpireYear == cardDto.ExpireYear);
            var payment = _paymentRepository.Get(x => x.Id == 1);
            if (card != null)
            {
                payment.IsPaid = true;
                _paymentRepository.UpdateAsync(payment.Id.ToString(), payment);
                card.Balance = card.Balance - payment.Amount;
                _cardRepository.UpdateAsync(card.Id.ToString(), card);
                return true;
            }

            return false;
        }
    }

    public class CardDto1
    {
        public string CardOwner { get; set; }
        public string CardNumber { get; set; }
        public int ExpireMonth { get; set; }
        public int ExpireYear { get; set; }
        public int CvcCode { get; set; }
        public decimal Balance { get; set; }
    }
}
