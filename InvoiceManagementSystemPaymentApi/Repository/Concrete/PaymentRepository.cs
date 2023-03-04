using Couchbase.Extensions.DependencyInjection;
using InvoiceManagementSystemPaymentApi.Entity;
using InvoiceManagementSystemPaymentApi.Repository.Abstract;

namespace InvoiceManagementSystemPaymentApi.Repository.Concrete
{
    public class PaymentRepository : CouchbaseRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(IBucketProvider bucketProvider) : base(bucketProvider, "Payment")
        {
        }
    }
}
