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
using System.Transactions;

namespace InvoiceManagementSystem.Business.Concrete
{
    public class DuesBusiness : IDuesBusiness
    {
        private readonly IDuesRepository _duesRepository;
        private readonly IApartmentBusiness _apartmentBusiness;
        private readonly ISuiteBusiness _suiteBusiness;

        public DuesBusiness(IDuesRepository duesRepository, IApartmentBusiness apartmentBusiness, ISuiteBusiness suiteBusiness)
        {
            _duesRepository = duesRepository;
            _apartmentBusiness = apartmentBusiness;
            _suiteBusiness = suiteBusiness;
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

        public IResult InsertRange(InsertRangeDuesDto insertRangeDuesDto)
        {
            var apartment = _apartmentBusiness.GetApartmentById(insertRangeDuesDto.ApartmentId);
            var suites = _suiteBusiness.GetAll().Data.Where(x => x.ApartmentId == insertRangeDuesDto.ApartmentId).ToList();
            if (suites != null)
            {
                foreach (var suite in suites)
                {
                    _duesRepository.Insert(new Dues
                    {
                        IsActive = true,
                        CreatedDate = DateTime.Now,
                        Type = insertRangeDuesDto.Type,
                        Amount = insertRangeDuesDto.Amount,
                        BillingPeriod = insertRangeDuesDto.BillingPeriod,
                        SuiteId = suite.SuiteId
                    });
                }
                return new SuccessResult("Otomatik fatura atamaları tamamlandı.");
            }
            return new ErrorResult();
        }
    }
}
