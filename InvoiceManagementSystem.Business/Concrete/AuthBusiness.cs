using InvoiceManagementSystem.Business.Abstract;
using InvoiceManagementSystem.Core.Utilities.Result;
using InvoiceManagementSystem.Core.Utilities.Security.JWT;
using InvoiceManagementSystem.DataAccess.Abstract;
using InvoiceManagementSystem.Entity.Entities.Concrete.Identity;
using InvoiceManagementSystem.Entity.Entities.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace InvoiceManagementSystem.Business.Concrete
{
    public class AuthBusiness : IAuthBusiness
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserRepository _userRepository;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthBusiness(ITokenService tokenService, UserManager<AppUser> userManager, IUserRepository userRepository, SignInManager<AppUser> signInManager, IHttpContextAccessor httpContextAccessor)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _userRepository = userRepository;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public IDataResult<AccessToken> CreateToken()
        {
            //var token = _tokenService.CreateAccessToken();

            //if (token != null)
            //{
            //    var refreshToken = _tokenService.CreateRefreshToken();
            //    var user = _userRepository.Get(x => x.Email == "test12@test.com");
            //    user.RefreshToken = refreshToken.Token;
            //    user.ExpireDate = refreshToken.ExpireDate;
            //    _userRepository.Update(user);

            //    return new SuccessDataResult<AccessToken>(token);
            //}
            return new ErrorDataResult<AccessToken>("Token oluşturulamadı.");
        }

        public async Task<IDataResult<AccessToken>> Login(UserLoginDto userLoginDto)
        {
            var userIdentity = await _userManager.FindByEmailAsync(userLoginDto.Email);
            var user = _userRepository.Get(x => x.Email == userLoginDto.Email);
            if (userIdentity != null && user != null)
            {
                SignInResult signinResult = await _signInManager.PasswordSignInAsync(userIdentity, userLoginDto.Password, false, true);
                if (signinResult.Succeeded)
                {
                    var claims = new List<Claim>
                    {
                        new(ClaimTypes.Name, $"{user.Firstname} {user.Lastname}"),
                        new(ClaimTypes.Email, user.Email)
                    };
                    var createToken = _tokenService.CreateAccessToken(claims);
                    var token = new AccessToken
                    {
                        Token = createToken.Token,
                        ExpireTime = createToken.ExpireTime
                    };                    
                    var createRefreshToken = _tokenService.CreateRefreshToken();
                    user.RefreshToken = createRefreshToken.Token;
                    user.ExpireDate = createRefreshToken.ExpireDate;
                    _userRepository.Update(user);

                    return new SuccessDataResult<AccessToken>(token);
                }
            }

            return new ErrorDataResult<AccessToken>("Bir hata oluştu.");
        }

        public IResult Register(UserLoginDto userLoginDto)
        {
            throw new NotImplementedException();
        }

        public IDataResult<AccessToken> TokenControl(string refreshToken)
        {
            //var userToken = _userRepository.Get(x => x.IsActive && x.RefreshToken == refreshToken && x.ExpireDate > DateTime.Now);
            //if (userToken != null)
            //{
            //    var token = _tokenService.CreateAccessToken();
            //    if (token != null)
            //    {
            //        return new SuccessDataResult<AccessToken>(token);
            //    }
            //}
            //else
            //{
            //    userToken.RefreshToken = null;
            //    userToken.ExpireDate = null;
            //    _userRepository.Update(userToken);
            //}
            return new ErrorDataResult<AccessToken>("Hata");
        }
    }
}
