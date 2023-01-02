using InvoiceManagementSystem.Core.Utilities.Result;
using InvoiceManagementSystem.Entity.Entities.Concrete;

namespace InvoiceManagementSystem.Business.Abstract
{
    public interface IUserAssignBusiness
    {
        IResult UserAssign(UserAssign userAssign);
        IDataResult<List<UserAssign>> UserAssignChecklist();
    }
}
