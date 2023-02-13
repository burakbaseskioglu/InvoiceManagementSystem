using InvoiceManagementSystem.Core.Utilities.Result;
using InvoiceManagementSystem.Core.Utilities.Security.JWT;
using InvoiceManagementSystem.Entity.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Business.Abstract
{
    public interface IAuthBusiness
    {
        Task<IDataResult<AccessToken>> Login(UserLoginDto userLoginDto);
        IResult Register(UserLoginDto userLoginDto);
        IDataResult<AccessToken> CreateToken();
        IDataResult<AccessToken> TokenControl(string refreshToken);
    }
}
