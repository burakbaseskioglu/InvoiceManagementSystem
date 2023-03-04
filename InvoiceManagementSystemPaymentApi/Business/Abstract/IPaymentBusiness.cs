using InvoiceManagementSystemPaymentApi.Entity;

namespace InvoiceManagementSystemPaymentApi.Business.Abstract
{
    public interface IPaymentBusiness
    {
        void Insert(Payment payment);
    }
}
