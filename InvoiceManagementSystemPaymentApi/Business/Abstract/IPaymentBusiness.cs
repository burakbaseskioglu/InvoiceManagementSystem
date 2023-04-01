using InvoiceManagementSystemPaymentApi.Entity;
using InvoiceManagementSystemPaymentApi.Entity.Dto;

namespace InvoiceManagementSystemPaymentApi.Business.Abstract
{
    public interface IPaymentBusiness
    {
        void Insert(Payment payment);
        bool Pay(CardDto cardDto);
        Payment GetPay();

    }
}
