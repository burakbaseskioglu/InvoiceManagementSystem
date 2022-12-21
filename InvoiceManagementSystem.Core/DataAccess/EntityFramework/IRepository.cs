using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Core.DataAccess.EntityFramework
{
    public interface IRepository<T> where T : class
    {
        void Insert(T entity);
        void Delete(T entiny);
        void Update(T entity);
        void UpdateRange(List<T> entities);
        T Get(Expression<Func<T, bool>> predicate);
        List<T> GetAll(Expression<Func<T, bool>> predicate = null);
    }
}
