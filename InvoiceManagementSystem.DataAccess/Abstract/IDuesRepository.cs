using InvoiceManagementSystem.Core.DataAccess.EntityFramework;
using InvoiceManagementSystem.Entity.Entities.Concrete;
using InvoiceManagementSystem.Entity.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.DataAccess.Abstract
{
    public interface IDuesRepository : IRepository<Dues>
    {
        List<DuesDto> GetAllDuesWithType();
    }
}
