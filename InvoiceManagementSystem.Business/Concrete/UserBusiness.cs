using InvoiceManagementSystem.Business.Abstract;
using InvoiceManagementSystem.Core.Utilities.Result;
using InvoiceManagementSystem.DataAccess.Abstract;
using InvoiceManagementSystem.Entity.Entities.Concrete;
using InvoiceManagementSystem.Entity.Entities.Concrete.Identity;
using InvoiceManagementSystem.Entity.Entities.Dto;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace InvoiceManagementSystem.Business.Concrete
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<AppUser> _userManager;

        public UserBusiness(IUserRepository userRepository, UserManager<AppUser> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }

        public IResult Delete(int userId)
        {
            var user = _userRepository.Get(x => x.Id == userId);
            if (user != null)
            {
                _userRepository.Update(new User
                {
                    IsActive = false,
                    DeletedDate = DateTime.Now,
                });
                return new SuccessResult("Kullanıcı silindi.");
            }
            return new ErrorResult();
        }

        public IDataResult<List<UserDto>> GetAll()
        {
            var users = _userRepository.GetAll(x => x.IsActive == true);
            var userList = new List<UserDto>();
            if (users != null)
            {
                foreach (var user in users)
                {
                    userList.Add(new UserDto
                    {
                        IsActive = user.IsActive,
                        CreatedDate = user.CreatedDate.Value.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                        Firstname = user.Firstname,
                        Lastname = user.Lastname,
                        IdentityNumber = user.IdentityNumber,
                        Email = user.Email,
                        Phone = user.Phone,
                        LicensePlate = user.LicensePlate,
                        IsManagement = user.IsManagement
                    });
                }
                return new SuccessDataResult<List<UserDto>>(userList);
            }
            return new ErrorDataResult<List<UserDto>>("Kullanıcı listesi bulunamadı.");
        }

        public IDataResult<UserDto> GetById(int userId)
        {
            var user = _userRepository.Get(x => x.Id == userId && x.IsActive == true);
            var newUser = new UserDto();

            if (user != null)
            {
                newUser = new UserDto
                {
                    IsActive = user.IsActive,
                    CreatedDate = user.CreatedDate.Value.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                    Firstname = user.Firstname,
                    Lastname = user.Lastname,
                    IdentityNumber = user.IdentityNumber,
                    Email = user.Email,
                    Phone = user.Phone,
                    LicensePlate = user.LicensePlate,
                    IsManagement = user.IsManagement
                };
                return new SuccessDataResult<UserDto>(newUser);
            }
            return new ErrorDataResult<UserDto>(newUser);
        }

        public IDataResult<User> GetUser(int userId)
        {
            var user = _userRepository.Get(x => x.Id == userId && x.IsActive == true);
            if (user != null)
            {
                return new SuccessDataResult<User>(user);
            }
            return new ErrorDataResult<User>(user);
        }

        public async Task<IResult> Insert(UserInsertDto userInsertDto)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    var user = _userRepository.Get(x => x.IdentityNumber == userInsertDto.IdentityNumber && x.IsActive == true);
                    if (user == null)
                    {
                        await _userRepository.InsertAsync(new User
                        {
                            CreatedDate = DateTime.Now,
                            IsActive = true,
                            Firstname = userInsertDto.Firstname,
                            Lastname = userInsertDto.Lastname,
                            IdentityNumber = userInsertDto.IdentityNumber,
                            Email = userInsertDto.Email,
                            Phone = userInsertDto.Phone,
                            LicensePlate = userInsertDto.LicensePlate,
                            IsManagement = userInsertDto.IsManagement
                        });

                        var appUser = new AppUser
                        {
                            UserName = userInsertDto.Email,
                            Email = userInsertDto.Email,
                        };
                        await _userManager.CreateAsync(appUser);
                        scope.Complete();
                        return new SuccessResult("Kullanıcı oluşturuldu.");
                    }
                    return new ErrorResult("Bu hesap zaten mevcut.");
                }
                catch (Exception)
                {
                    scope.Dispose();
                    return new ErrorResult();
                }
            }
        }

        public IResult Update(UserInsertDto userInsertDto)
        {
            var user = _userRepository.Get(x => x.Id == 1 && x.IsActive == true);
            if (user != null)
            {
                user.UpdatedDate = DateTime.Now;
                user.Firstname = user.Firstname != default ? userInsertDto.Firstname : user.Firstname;
                user.Lastname = user.Lastname != default ? userInsertDto.Lastname : user.Lastname;
                user.IdentityNumber = user.IdentityNumber != default ? userInsertDto.IdentityNumber : user.IdentityNumber;
                user.Email = user.Email != default ? userInsertDto.Email : user.Email;
                user.Phone = user.Phone != default ? userInsertDto.Phone : user.Phone;
                user.LicensePlate = user.LicensePlate != default ? userInsertDto.LicensePlate : user.LicensePlate;
                user.IsManagement = user.IsManagement != default ? userInsertDto.IsManagement : user.IsManagement;
                _userRepository.Update(user);
                return new SuccessResult("Güncelleme işlemi başarılı.");
            }
            return new ErrorResult();
        }
    }
}
