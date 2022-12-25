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
    public class DuesBusiness : IDuesBusiness
    {
        private readonly IDuesRepository _duesRepository;

        public DuesBusiness(IDuesRepository duesRepository)
        {
            _duesRepository = duesRepository;
        }

        public IResult Insert(InsertDuesDto insertDuesDto)
        {
            var dues = _duesRepository.Get(x => x.SuiteId == insertDuesDto.SuiteId &&
                x.Type == insertDuesDto.Type &&
                x.BillingPeriod == insertDuesDto.BillingPeriod &&
                x.IsActive == true);
            if (dues == null)
            {
                _duesRepository.Insert(new Dues
                {
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    Type = insertDuesDto.Type,
                    BillingPeriod = insertDuesDto.BillingPeriod,
                    Amount = insertDuesDto.Amount,
                    SuiteId = insertDuesDto.SuiteId,
                });
                return new SuccessResult();
            }
            return new ErrorResult("Bu fatura daha önceden eklenmiş.");
        }

        public IResult InsertRange(InsertDuesDto insertDuesDto)
        {
            return new SuccessResult();
        }
    }
}
