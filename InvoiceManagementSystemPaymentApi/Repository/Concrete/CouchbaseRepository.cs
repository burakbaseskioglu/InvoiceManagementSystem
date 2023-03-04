using Couchbase;
using Couchbase.Extensions.DependencyInjection;
using Couchbase.KeyValue;
using Couchbase.Linq;
using InvoiceManagementSystemPaymentApi.Repository.Abstract;
using System.Linq.Expressions;

namespace InvoiceManagementSystemPaymentApi.Repository.Concrete
{
    public class CouchbaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly IBucket _bucket;
        private readonly ICouchbaseCollection _collection;
        private readonly BucketContext _context;

        public CouchbaseRepository(IBucketProvider bucketProvider, string collectionName)
        {
            _bucket = bucketProvider.GetBucketAsync("PaymentApi").GetAwaiter().GetResult();
            _collection = _bucket.Collection(collectionName);
            _context= new BucketContext(_bucket);
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.RemoveAsync(id);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _context.Query<T>().FirstOrDefault(filter);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter)
        {
            return _context.Query<T>().Where(filter);
        }

        public async Task InsertAsync(string id, T entity)
        {
            await _collection.InsertAsync<T>(id, entity);
        }

        public async Task UpdateAsync(string id, T entity)
        {
            await _collection.UpsertAsync(id, entity);
        }
    }
}
