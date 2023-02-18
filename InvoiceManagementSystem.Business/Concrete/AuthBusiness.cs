using InvoiceManagementSystem.Business.Abstract;
using InvoiceManagementSystem.Core.Utilities.Result;
using InvoiceManagementSystem.Core.Utilities.Security.JWT;
using InvoiceManagementSystem.DataAccess.Abstract;
using InvoiceManagementSystem.Entity.Entities.Concrete;
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

        public AuthBusiness(ITokenService tokenService, UserManager<AppUser> userManager, IUserRepository userRepository, SignInManager<AppUser> signInManager)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _userRepository = userRepository;
            _signInManager = signInManager;
        }

        public async Task<IDataResult<AccessToken>> Login(UserLoginDto userLoginDto)
        {
            try
            {
                var findUser = await _userManager.FindByEmailAsync(userLoginDto.Email);
                var user = _userRepository.Get(x => x.Email == userLoginDto.Email);
                if (findUser != null && user != null)
                {
                    SignInResult signinResult = await _signInManager.PasswordSignInAsync(findUser, userLoginDto.Password, false, true);
                    if (signinResult.Succeeded)
                    {
                        var claims = new List<Claim>
                    {
                        new(ClaimTypes.Name, $"{user.Firstname} {user.Lastname}"),
                        new(ClaimTypes.Email, user.Email),
                        new(ClaimTypes.Role, "Management")
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
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IResult> Register(UserRegisterDto userRegisterDto)
        {
            try
            {
                var user = _userRepository.Get(x => x.Email == userRegisterDto.Email);
                var identityUser = await _userManager.FindByEmailAsync(userRegisterDto.Email);
                if (user == null && identityUser == null)
                {
                    var newUser = new User
                    {
                        CreatedDate = DateTime.Now,
                        IsActive = true,
                        Firstname = userRegisterDto.Firstname,
                        Lastname = userRegisterDto.Lastname,
                        Email = userRegisterDto.Email,
                        IdentityNumber = userRegisterDto.IdentityNumber,
                        Phone = userRegisterDto.PhoneNumber
                    };
                    await _userRepository.InsertAsync(newUser);

                    var appUser = new AppUser
                    {
                        UserName = userRegisterDto.Email,
                        Email = userRegisterDto.Email
                    };
                    IdentityResult result = await _userManager.CreateAsync(appUser, userRegisterDto.Password);
                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(appUser, "User");
                        return new SuccessResult("Kayıt işlemi başarı ile tamamlandı.");
                    }
                }

                return new ErrorResult("Bu mail adresine tanımlı bir hesap mevcut.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IDataResult<AccessToken> TokenControl(string refreshToken)
        {
            var userToken = _userRepository.Get(x => x.IsActive && x.RefreshToken == refreshToken && x.ExpireDate > DateTime.Now);
            if (userToken != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, $"{userToken.Firstname} {userToken.Lastname}"),
                    new Claim(ClaimTypes.Email, userToken.Email),
                    new Claim(ClaimTypes.Role, "Management")
                };
                var token = _tokenService.CreateAccessToken(claims);
                if (token != null)
                {
                    return new SuccessDataResult<AccessToken>(token);
                }
            }
            else
            {
                userToken.RefreshToken = null;
                userToken.ExpireDate = null;
                _userRepository.Update(userToken);
            }
            return new ErrorDataResult<AccessToken>("Hata");
        }
    }
}
