namespace InvoiceManagementSystemPaymentApi.Repository.Abstract
{
    public interface IBaseRepository<T> where T : class
    {
        Task InsertAsync(T entity);
    }
}
