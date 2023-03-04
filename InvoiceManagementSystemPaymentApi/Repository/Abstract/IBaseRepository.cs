using System.Linq.Expressions;

namespace InvoiceManagementSystemPaymentApi.Repository.Abstract
{
    public interface IBaseRepository<T> where T : class
    {
        Task InsertAsync(string id,T entity);
        Task UpdateAsync(string id, T entity);
        Task DeleteAsync(string id);
        T Get(Expression<Func<T, bool>> filter);
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter);
    }
}
