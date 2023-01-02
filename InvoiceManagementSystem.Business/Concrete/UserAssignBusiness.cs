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
    public class UserAssignBusiness : IUserAssignBusiness
    {
        private readonly IUserAssignRepository _userAssignRepository;

        public UserAssignBusiness(IUserAssignRepository userAssignRepository)
        {
            _userAssignRepository = userAssignRepository;
        }

        public IResult UserAssign(UserAssign userAssign)
        {
            var user = _userAssignRepository.Get(x => x.UserId != userAssign.UserId && x.SuiteId == userAssign.SuiteId);
            if (user == null) 
            {
                _userAssignRepository.Insert(new Entity.Entities.Concrete.UserAssign
                {
                    SuiteId = userAssign.SuiteId,
                    UserId = userAssign.UserId,
                });
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IDataResult<List<UserAssign>> UserAssignChecklist()
        {
            var userAssignList = _userAssignRepository.GetAll(x=>x.IsActive);
            if (userAssignList.Count>0)
            {
                return new SuccessDataResult<List<UserAssign>>(userAssignList);
            }
            return new ErrorDataResult<List<UserAssign>>("");
        }
    }
}
