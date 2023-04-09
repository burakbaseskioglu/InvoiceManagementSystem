using InvoiceManagementSystemPaymentApi.Entity;
using InvoiceManagementSystemPaymentApi.Entity.Dto;
using InvoiceManagementSystemPaymentApi.Utilities.Result;
using IResult = InvoiceManagementSystemPaymentApi.Utilities.Result.IResult;

namespace InvoiceManagementSystemPaymentApi.Business.Abstract
{
    public interface IPaymentBusiness
    {
        IResult Insert(Payment payment);
        IDataResult<bool> Pay(CardDto cardDto, int billId);
    }
}
