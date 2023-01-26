using InvoiceManagementSystem.Business.Abstract;
using InvoiceManagementSystem.Core.Utilities.Result;
using InvoiceManagementSystem.Core.Utilities.Security.JWT;
using InvoiceManagementSystem.Entity.Entities.Concrete.Identity;
using InvoiceManagementSystem.Entity.Entities.Dto;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Business.Concrete
{
    public class AuthBusiness : IAuthBusiness
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<AppUser> _userManager;

        public AuthBusiness(ITokenService tokenService, UserManager<AppUser> userManager)
        {
            _tokenService = tokenService;
            _userManager = userManager;
        }

        public IDataResult<AccessToken> CreateToken()
        {
            var token = _tokenService.CreateAccessToken();
            if (token!=null)
            {
                return new SuccessDataResult<AccessToken>(token);
            }
            return new ErrorDataResult<AccessToken>("Token oluşturulamadı.");
        }

        public IResult Login(UserLoginDto userLoginDto)
        {
            throw new NotImplementedException();
        }

        public IResult Register(UserLoginDto userLoginDto)
        {
            throw new NotImplementedException();
        }
    }
}
