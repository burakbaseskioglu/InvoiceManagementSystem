using InvoiceManagementSystem.Core.Utilities.Result;
using InvoiceManagementSystem.Entity.Entities.Concrete;
using InvoiceManagementSystem.Entity.Entities.Dto;

namespace InvoiceManagementSystem.Business.Abstract
{
    public interface IUserAssignBusiness
    {
        IResult UserAssign(UserAssignDto userAssignDto);
        IDataResult<List<UserAssign>> UserAssignChecklist();
        IResult UserAssignManagementApprove(UserAssignManagementDto userAssignManagementDto);
    }
}
