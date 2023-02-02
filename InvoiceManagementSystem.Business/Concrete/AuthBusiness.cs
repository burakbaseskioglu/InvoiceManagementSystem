using InvoiceManagementSystem.Business.Abstract;
using InvoiceManagementSystem.Core.Utilities.Result;
using InvoiceManagementSystem.Core.Utilities.Security.JWT;
using InvoiceManagementSystem.DataAccess.Abstract;
using InvoiceManagementSystem.Entity.Entities.Concrete.Identity;
using InvoiceManagementSystem.Entity.Entities.Dto;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
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
        private readonly IUserRepository _userRepository;

        public AuthBusiness(ITokenService tokenService, UserManager<AppUser> userManager, IUserRepository userRepository)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _userRepository = userRepository;
        }

        public IDataResult<AccessToken> CreateToken()
        {
            var token = _tokenService.CreateAccessToken();

            if (token != null)
            {
                var refreshToken = _tokenService.CreateRefreshToken();
                var user = _userRepository.Get(x => x.Email == "test12@test.com");
                user.RefreshToken = refreshToken.Token;
                user.ExpireDate = refreshToken.ExpireDate;
                _userRepository.Update(user);

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

        public IDataResult<AccessToken> TokenControl(string refreshToken)
        {
            var userToken = _userRepository.Get(x => x.IsActive && x.RefreshToken == refreshToken && x.ExpireDate > DateTime.Now);
            if (userToken != null) 
            {
                var token = _tokenService.CreateAccessToken();
                if (token != null)
                {
                    return new SuccessDataResult<AccessToken>(token);
                }
            }
            return new ErrorDataResult<AccessToken>("Hata");
        }
    }
}
