using InvoiceManagementSystem.Core.DataAccess.EntityFramework;
using InvoiceManagementSystem.Entity.Entities.Concrete;

namespace InvoiceManagementSystem.DataAccess.Abstract
{
    public interface IUserAssignRepository : IRepository<UserAssign> 
    {
    }
}
