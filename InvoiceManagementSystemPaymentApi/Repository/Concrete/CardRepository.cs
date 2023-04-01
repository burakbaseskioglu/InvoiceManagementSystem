using Couchbase.Extensions.DependencyInjection;
using InvoiceManagementSystemPaymentApi.Entity;
using InvoiceManagementSystemPaymentApi.Repository.Abstract;

namespace InvoiceManagementSystemPaymentApi.Repository.Concrete
{
    public class CardRepository : CouchbaseRepository<Card>, ICardRepository
    {
        public CardRepository(IBucketProvider bucketProvider) : base(bucketProvider, "Card")
        {
        }
    }
}
