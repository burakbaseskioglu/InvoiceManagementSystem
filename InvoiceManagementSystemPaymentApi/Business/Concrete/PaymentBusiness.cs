using InvoiceManagementSystemPaymentApi.Business.Abstract;
using InvoiceManagementSystemPaymentApi.Entity;
using InvoiceManagementSystemPaymentApi.Entity.Dto;
using InvoiceManagementSystemPaymentApi.Repository.Abstract;
using InvoiceManagementSystemPaymentApi.Utilities.Result;
using IResult = InvoiceManagementSystemPaymentApi.Utilities.Result.IResult;

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

        public IResult Insert(Payment payment)
        {
            var getPayment = _paymentRepository.Get(x => x.Id == payment.Id);
            if (getPayment == null)
            {
                _paymentRepository.InsertAsync(payment.Id.ToString(), payment);
                return new SuccessResult("Ödeme eklendi.");
            }
            return new ErrorResult("Ödeme zaten mevcut.");
        }

        public IDataResult<bool> Pay(CardDto cardDto, int billId)
        {
            var payment = _paymentRepository.Get(x => x.Id == billId);
            if (payment != null)
            {
                var card = _cardRepository.Get(x => x.CardOwner.ToLower() == cardDto.CardOwner.ToLower() &&
                x.CardNumber == cardDto.CardNumber &&
                x.CvcCode == cardDto.CvcCode &&
                x.ExpireMonth == cardDto.ExpireMonth &&
                x.ExpireYear == cardDto.ExpireYear);

                if (card != null)
                {
                    if (card.Balance > payment.Amount)
                    {
                        card.Balance = card.Balance - payment.Amount;
                        _cardRepository.UpdateAsync(card.Id.ToString(), card);
                        payment.IsPaid = true;
                        _paymentRepository.UpdateAsync(payment.Id.ToString(), payment);
                        return new SuccessDataResult<bool>(true, "Ödeme tamamlandı.");
                    }
                    return new ErrorDataResult<bool>("Bakiye yetersiz");
                }
                return new ErrorDataResult<bool>("Kart bilgileri geçersiz.");
            }

            return new ErrorDataResult<bool>("Fatura bulunamadı.");
        }
    }
}
