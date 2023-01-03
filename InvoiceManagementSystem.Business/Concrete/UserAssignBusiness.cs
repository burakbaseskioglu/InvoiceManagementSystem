using InvoiceManagementSystem.Business.Abstract;
using InvoiceManagementSystem.Core.Utilities.Result;
using InvoiceManagementSystem.DataAccess.Abstract;
using InvoiceManagementSystem.Entity.Entities.Concrete;
using InvoiceManagementSystem.Entity.Entities.Dto;
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
        private readonly ISuiteBusiness _suiteBusiness;

        public UserAssignBusiness(IUserAssignRepository userAssignRepository, ISuiteBusiness suiteBusiness)
        {
            _userAssignRepository = userAssignRepository;
            _suiteBusiness = suiteBusiness;
        }

        public IResult UserAssign(UserAssignDto userAssignDto)
        {
            var user = _userAssignRepository.Get(x => x.UserId == userAssignDto.UserId && x.SuiteId == userAssignDto.SuiteId);
            if (user == null)
            {
                _userAssignRepository.Insert(new UserAssign
                {
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    SuiteId = userAssignDto.SuiteId,
                    UserId = userAssignDto.UserId,
                });
                return new SuccessResult("Daire seçiminiz tamamlanmıştır ve yönetici onayına sunulmuştur.");
            }
            return new ErrorResult("Daire seçiminde bir hata oluştu.");
        }

        public IDataResult<List<UserAssign>> UserAssignChecklist()
        {
            var userAssignList = _userAssignRepository.GetAll(x => x.IsActive && x.IsManagementApprove != true);
            if (userAssignList.Count > 0)
            {
                return new SuccessDataResult<List<UserAssign>>(userAssignList);
            }
            return new ErrorDataResult<List<UserAssign>>("Daire onayı için yönetici listesi bulunamadı.");
        }

        public IResult UserAssignManagementApprove(UserAssignManagementDto userAssignManagementDto)
        {
            var userAssign = _userAssignRepository.Get(x => x.UserId == userAssignManagementDto.UserId && x.SuiteId == userAssignManagementDto.SuiteId);
            IResult result = new ErrorResult();
            if (userAssign != null)
            {
                userAssign.UpdatedDate = DateTime.Now;
                userAssign.IsManagementApprove = true;
                _userAssignRepository.Update(userAssign);
                result = _suiteBusiness.AssignUser(userAssignManagementDto.UserId, userAssignManagementDto.SuiteId);
                return new SuccessResult(result.Message);
            }
            return new ErrorResult(result.Message);
        }
    }
}
