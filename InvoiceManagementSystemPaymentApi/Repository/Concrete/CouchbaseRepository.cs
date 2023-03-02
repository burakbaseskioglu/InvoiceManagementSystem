using Couchbase;
using Couchbase.Extensions.DependencyInjection;
using Couchbase.KeyValue;
using InvoiceManagementSystemPaymentApi.Repository.Abstract;

namespace InvoiceManagementSystemPaymentApi.Repository.Concrete
{
    public class CouchbaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly IBucket _bucket;
        private readonly ICouchbaseCollection _collection;

        public CouchbaseRepository(IBucketProvider bucketProvider, string collectionName)
        {
            _bucket = bucketProvider.GetBucketAsync("PaymentApi").GetAwaiter().GetResult();
            _collection = _bucket.Collection(collectionName);
        }
        public async Task InsertAsync(T entity)
        {
            await _collection.InsertAsync<T>("1", entity);
        }
    }
}
