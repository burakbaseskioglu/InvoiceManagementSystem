using InvoiceManagementSystem.Core.Utilities.Result;
using InvoiceManagementSystem.Entity.Entities.Concrete;
using InvoiceManagementSystem.Entity.Entities.Dto;

namespace InvoiceManagementSystem.Business.Abstract
{
    public interface IUserBusiness
    {
        IDataResult<List<UserDto>> GetAll();
        IDataResult<UserDto> GetById(int userId);
        Task<IResult> Insert(UserInsertDto userInsertDto);
        IResult Update(UserInsertDto userInsertDto);
        IResult Delete(int userId);
        IDataResult<User> GetUser(int userId);
        IResult Login(UserLoginDto userLoginDto);
    }
}
