using InvoiceManagementSystem.Core.DataAccess.EntityFramework;
using InvoiceManagementSystem.Entity.Entities.Concrete;
using InvoiceManagementSystem.Entity.Entities.Dto;

namespace InvoiceManagementSystem.DataAccess.Abstract
{
    public interface ISuiteRepository : IRepository<Suite>
    {
        List<SuiteDto> GetAllSuitesWithUsers();
        SuiteDto GetSuiteWithUser(int suiteId);
    }
}
