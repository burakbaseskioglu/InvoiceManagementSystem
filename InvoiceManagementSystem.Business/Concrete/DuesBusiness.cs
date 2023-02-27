﻿using InvoiceManagementSystem.Business.Abstract;
using InvoiceManagementSystem.Core.Enums;
using InvoiceManagementSystem.Core.Utilities.Result;
using InvoiceManagementSystem.DataAccess.Abstract;
using InvoiceManagementSystem.Entity.Entities.Concrete;
using InvoiceManagementSystem.Entity.Entities.Dto;
using InvoiceManagementSystem.Publishers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private readonly IMessagePublisher _messagePublisher;

        public DuesBusiness(IDuesRepository duesRepository, IApartmentBusiness apartmentBusiness, ISuiteBusiness suiteBusiness, IMessagePublisher messagePublisher)
        {
            _duesRepository = duesRepository;
            _apartmentBusiness = apartmentBusiness;
            _suiteBusiness = suiteBusiness;
            _messagePublisher = messagePublisher;
        }

        public IDataResult<List<DuesDto>> PaidDebtList()
        {
            var dues = _duesRepository.GetAllDuesWithType();
            var duesList = new List<DuesDto>();
            if (dues.Count > 0)
            {
                foreach (var item in dues.Where(x => x.IsPaid))
                {
                    duesList.Add(new DuesDto
                    {
                        Id = item.Id,
                        IsPaid = item.IsPaid,
                        Amount = item.Amount,
                        BillingPeriod = item.BillingPeriod,
                        Type = item.Type,
                        SuiteId = item.SuiteId
                    });
                }
                return new SuccessDataResult<List<DuesDto>>(duesList);
            }
            return new ErrorDataResult<List<DuesDto>>("Ödenmiş fatura listesi bulunamadı.");
        }

        public IResult Delete(int duesId)
        {
            var dues = _duesRepository.Get(x => x.Id == duesId && x.IsActive);
            if (dues != null)
            {
                dues.IsActive = false;
                dues.DeletedDate = DateTime.Now;
                _duesRepository.Update(dues);
                return new SuccessResult("Fatura başarı ile silindi.");
            }
            return new SuccessResult("Fatura bulunamadı.");
        }

        public IDataResult<List<DuesDto>> GetAll()
        {
            var duesList = _duesRepository.GetAllDuesWithType();
            var newDuesList = new List<DuesDto>();
            if (duesList != null)
            {
                foreach (var item in duesList)
                {
                    newDuesList.Add(new DuesDto
                    {
                        Id = item.Id,
                        IsPaid = item.IsPaid,
                        Amount = item.Amount,
                        BillingPeriod = item.BillingPeriod,
                        Type = item.Type,
                        SuiteId = item.SuiteId
                    });
                }
                return new SuccessDataResult<List<DuesDto>>(newDuesList);
            }
            return new ErrorDataResult<List<DuesDto>>("Fatura listesi bulunamadı.");
        }

        public IResult Insert(InsertDuesDto insertDuesDto)
        {
            var dues = _duesRepository.Get(x => x.SuiteId == insertDuesDto.SuiteId &&
                x.BillTypeId == insertDuesDto.Type &&
                x.BillingPeriod == insertDuesDto.BillingPeriod &&
                x.IsActive);
            if (dues == null)
            {
                _duesRepository.Insert(new Dues
                {
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    IsPaid = false,
                    BillTypeId = insertDuesDto.Type,
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
            try
            {
                var suites = _suiteBusiness.GetAll().Data.Where(x => x.ApartmentId == insertRangeDuesDto.ApartmentId).ToList();
                if (suites != null)
                {
                    foreach (var suite in suites)
                    {
                        _duesRepository.Insert(new Dues
                        {
                            IsActive = true,
                            CreatedDate = DateTime.Now,
                            IsPaid = false,
                            BillTypeId = insertRangeDuesDto.Type,
                            Amount = insertRangeDuesDto.Amount,
                            BillingPeriod = insertRangeDuesDto.BillingPeriod,
                            SuiteId = suite.SuiteId
                        });
                    }
                    return new SuccessResult("Otomatik fatura atamaları tamamlandı.");
                }
                return new ErrorResult();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IDataResult<List<DuesDto>> UnpaidDebtList()
        {
            var dues = _duesRepository.GetAllDuesWithType();
            var duesList = new List<DuesDto>();
            if (dues.Count > 0)
            {
                foreach (var item in dues.Where(x => x.IsPaid == false))
                {
                    duesList.Add(new DuesDto
                    {
                        Id = item.Id,
                        IsPaid = item.IsPaid,
                        Amount = item.Amount,
                        BillingPeriod = item.BillingPeriod,
                        Type = item.Type,
                        SuiteId = item.SuiteId
                    });
                }
                return new SuccessDataResult<List<DuesDto>>(duesList);
            }
            return new ErrorDataResult<List<DuesDto>>("Ödenmemiş fatura listesi bulunamadı.");
        }

        public IResult Update(InsertDuesDto insertDuesDto)
        {
            var dues = _duesRepository.Get(x => x.IsActive && x.BillingPeriod == insertDuesDto.BillingPeriod);
            if (dues != null)
            {
                dues.UpdatedDate = DateTime.Now;
                dues.IsPaid = insertDuesDto.IsPaid != default ? insertDuesDto.IsPaid : dues.IsPaid;
                dues.BillingPeriod = insertDuesDto.BillingPeriod != default ? insertDuesDto.BillingPeriod : dues.BillingPeriod;
                dues.BillTypeId = insertDuesDto.Type != default ? insertDuesDto.Type : dues.BillTypeId;
                dues.SuiteId = insertDuesDto.SuiteId != default ? insertDuesDto.SuiteId : dues.SuiteId;
                dues.Amount = insertDuesDto.Amount != default ? insertDuesDto.Amount : dues.Amount;
                _duesRepository.Update(dues);
                return new SuccessResult("Fatura başarı ile güncellendi.");
            }
            return new ErrorResult("Fatura bulunamadı");
        }

        public IResult PayTheDue(DuesPaymentDto duesPaymentDto)
        {
            var dues = _duesRepository.Get(x => x.Id == duesPaymentDto.Id);
            if (dues != null)
            {
                _messagePublisher.Publish(duesPaymentDto);
                return new SuccessResult();
            }

            return new ErrorResult("Fatura bulunamadı.");
        }
    }
}
