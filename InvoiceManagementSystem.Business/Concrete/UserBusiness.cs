using InvoiceManagementSystem.Business.Abstract;
using InvoiceManagementSystem.Core.Utilities.Result;
using InvoiceManagementSystem.DataAccess.Abstract;
using InvoiceManagementSystem.Entity.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Business.Concrete
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserRepository _userRepository;

        public UserBusiness(IUserRepository userRepository)
        {
            _userRepository= userRepository;
        }

        public IDataResult<User> GetUser(int userId)
        {
            var user = _userRepository.Get(x => x.Id == userId);
            return new SuccessDataResult<User>(user);
        }
    }
}
