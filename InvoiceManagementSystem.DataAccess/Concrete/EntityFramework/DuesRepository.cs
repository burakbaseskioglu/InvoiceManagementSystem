using InvoiceManagementSystem.Core.DataAccess.EntityFramework;
using InvoiceManagementSystem.DataAccess.Abstract;
using InvoiceManagementSystem.Entity.Entities.Concrete;
using InvoiceManagementSystem.Entity.Entities.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.DataAccess.Concrete.EntityFramework
{
    public class DuesRepository : EfRepository<Dues, AppDbContext>, IDuesRepository
    {
        public List<DuesDto> GetAllDuesWithType()
        {
            using (var context = new AppDbContext())
            {
                var dues = context.Dues.Include(x => x.BillType).Where(x => x.IsActive).Select(y => new DuesDto
                {
                    IsPaid = y.IsPaid,
                    Amount = y.Amount,
                    BillingPeriod = y.BillingPeriod,
                    SuiteId = y.SuiteId,
                    Type = y.BillType.Type
                });
                return dues.ToList();
            }
        }
    }
}
