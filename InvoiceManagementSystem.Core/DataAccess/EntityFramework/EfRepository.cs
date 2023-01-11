using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Core.DataAccess.EntityFramework
{
    public class EfRepository<T, TContext> : IRepository<T> where T : class where TContext : DbContext, new()
    {
        public void Delete(T entiny)
        {
            using (TContext context = new TContext())
            {
                context.Entry(entiny).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            using (TContext context = new TContext())
            {
                return context.Set<T>().SingleOrDefault(predicate);
            }
        }

        public List<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            using (TContext context = new TContext())
            {
                return predicate == null ? context.Set<T>().ToList() : context.Set<T>().Where(predicate).ToList();
            }
        }

        public void Insert(T entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public async Task InsertAsync(T entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                await context.SaveChangesAsync();
            }
        }

        public void InsertRange(List<T> entity)
        {
            using (TContext context = new TContext())
            {
                context.Set<T>().AddRange(entity);
                context.SaveChanges();
            }
        }

        public void Update(T entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void UpdateRange(List<T> entities)
        {
            using (TContext context = new TContext())
            {
                context.Set<T>().UpdateRange(entities);
                context.SaveChanges();
            }
        }
    }
}
