using InvoiceManagementSystem.Core.DataAccess.EntityFramework;
using InvoiceManagementSystem.DataAccess.Abstract;
using InvoiceManagementSystem.Entity.Entities.Concrete;

namespace InvoiceManagementSystem.DataAccess.Concrete.EntityFramework
{
    public class UserAssignRepository : EfRepository<UserAssign, AppDbContext>, IUserAssignRepository
    {
    }
}
