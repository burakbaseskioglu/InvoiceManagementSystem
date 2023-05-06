using InvoiceManagementSystem.Business.Abstract;
using InvoiceManagementSystem.Core.Utilities.Result;
using InvoiceManagementSystem.Core.Utilities.Service.HttpService;
using InvoiceManagementSystem.DataAccess.Abstract;
using InvoiceManagementSystem.Entity.Entities.Concrete;
using InvoiceManagementSystem.Entity.Entities.Dto;
using InvoiceManagementSystem.Publishers;

namespace InvoiceManagementSystem.Business.Concrete
{
    public class DuesBusiness : IDuesBusiness
    {
        private readonly IDuesRepository _duesRepository;
        private readonly IApartmentBusiness _apartmentBusiness;
        private readonly ISuiteBusiness _suiteBusiness;
        private readonly IMessagePublisher _messagePublisher;
        private readonly IHttpService _httpService;

        public DuesBusiness(IDuesRepository duesRepository, IApartmentBusiness apartmentBusiness, ISuiteBusiness suiteBusiness, IMessagePublisher messagePublisher, IHttpService httpService)
        {
            _duesRepository = duesRepository;
            _apartmentBusiness = apartmentBusiness;
            _suiteBusiness = suiteBusiness;
            _messagePublisher = messagePublisher;
            _httpService = httpService;
        }

        public IDataResult<List<DuesDto>> PaidDebtList()
        {
            var dues = _duesRepository.GetAllPaidDebtList();
            var duesList = new List<DuesDto>();
            if (dues.Any())
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
            var duesList = _duesRepository.GetAllDebtList();
            var newDuesList = new List<DuesDto>();
            if (duesList.Any())
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
                var getInsertDues = _duesRepository.Get(x => x.IsActive && x.SuiteId == insertDuesDto.SuiteId);
                _messagePublisher.Publish<DuesPaymentDto>("payment", new DuesPaymentDto
                {
                    Id = getInsertDues.Id,
                    BillTypeId = insertDuesDto.Type,
                    Amount = insertDuesDto.Amount,
                    BillingPeriod = insertDuesDto.BillingPeriod,
                    SuiteId = insertDuesDto.SuiteId
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
                        var dues = _duesRepository.Get(x => x.IsActive && x.SuiteId == suite.SuiteId);
                        _messagePublisher.Publish<DuesPaymentDto>("payment", new DuesPaymentDto
                        {
                            Id = dues.Id,
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
            var dues = _duesRepository.GetAllUnpaidDebtList();
            var duesList = new List<DuesDto>();
            if (dues.Count > 0)
            {
                foreach (var item in dues)
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
                _messagePublisher.Publish("payment", duesPaymentDto);
                return new SuccessResult();
            }

            return new ErrorResult("Fatura bulunamadı.");
        }

        public async Task<IResult> PayTheDueCard(CardDto cardDto, int billId)
        {
            var result = await _httpService.PostAsync("Payment/pay", cardDto, billId);

            if (result.success)
            {
                var dues = _duesRepository.Get(x => x.Id == billId);
                dues.IsPaid = true;
                dues.IsActive = false;
                _duesRepository.Update(dues);
                return new SuccessResult(result.message);
            }

            return new ErrorResult(result.message);
        }
    }
}
