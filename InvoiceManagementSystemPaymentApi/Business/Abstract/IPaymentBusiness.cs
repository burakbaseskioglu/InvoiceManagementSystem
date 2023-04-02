using InvoiceManagementSystemPaymentApi.Entity;
using InvoiceManagementSystemPaymentApi.Entity.Dto;
using InvoiceManagementSystemPaymentApi.Utilities.Result;

namespace InvoiceManagementSystemPaymentApi.Business.Abstract
{
    public interface IPaymentBusiness
    {
        void Insert(Payment payment);
        IDataResult<bool> Pay(CardDto cardDto, int billId);
        Payment GetPay();

    }
}
