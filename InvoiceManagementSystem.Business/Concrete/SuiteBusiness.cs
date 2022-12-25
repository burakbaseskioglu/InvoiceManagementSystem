using InvoiceManagementSystem.Business.Abstract;
using InvoiceManagementSystem.Core.Utilities.Result;
using InvoiceManagementSystem.DataAccess.Abstract;
using InvoiceManagementSystem.Entity.Entities.Concrete;
using InvoiceManagementSystem.Entity.Entities.Dto;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Drawing;
using System.Numerics;
using InvoiceManagementSystem.Core.Enums;

namespace InvoiceManagementSystem.Business.Concrete
{
    public class SuiteBusiness : ISuiteBusiness
    {
        private readonly ISuiteRepository _suiteRepository;
        private readonly IUserBusiness _userBusiness;

        public SuiteBusiness(ISuiteRepository suiteRepository, IUserBusiness userBusiness)
        {
            _suiteRepository = suiteRepository;
            _userBusiness = userBusiness;
        }

        public IResult Delete(int suiteId)
        {
            var suite = _suiteRepository.Get(x => x.Id == suiteId);
            if (suite != null)
            {
                suite.IsActive = false;
                suite.DeletedDate = DateTime.Now;
                _suiteRepository.Update(suite);
                return new SuccessResult();
            }
            return new ErrorResult("Daire bulunamadı.");
        }

        public IDataResult<List<SuiteDto>> GetAll()
        {
            var suites = _suiteRepository.GetAllSuitesWithUsers();
            if (suites != null)
            {
                return new SuccessDataResult<List<SuiteDto>>(suites);
            }
            return new ErrorDataResult<List<SuiteDto>>("Daire listesi bulunamadı.");
        }

        public IDataResult<SuiteDto> GetById(int suiteId)
        {
            var suite = _suiteRepository.GetSuiteWithUser(suiteId);
            if (suite != null)
            {
                return new SuccessDataResult<SuiteDto>(suite);
            }
            return new ErrorDataResult<SuiteDto>("Daire bulunamadı.");
        }

        public IResult Insert(CreateSuiteDto createSuiteDto)
        {
            if (createSuiteDto != null)
            {
                _suiteRepository.Insert(new Suite
                {
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    Block = createSuiteDto.Block,
                    Floor = createSuiteDto.Floor,
                    Type = createSuiteDto.Type,
                    NumberOfSuite = createSuiteDto.DoorNumber,
                    Status = createSuiteDto.Status,
                    IsTenant = createSuiteDto.IsTenant,
                    ApartmentId = createSuiteDto.ApartmentId,
                    UserId = createSuiteDto.UserId
                });
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IResult InsertRange(InsertRangeSuiteDto suiteDto)
        {
            int k = 1;
            for (int i = 1; i <= suiteDto.NumberOfFloor; i++)
            {
                for (int j = 1; j <= suiteDto.SuiteOfFloorCount; j++)
                {
                    var suite = new Suite
                    {
                        IsActive = true,
                        CreatedDate = DateTime.Now,
                        Block = suiteDto.BlockCode,
                        Floor = i,
                        Type = suiteDto.Type,
                        NumberOfSuite = k++,
                        Status = false,
                        IsTenant = false,
                        UserId = _userBusiness.GetUser((int)StandardUser.StandardUser).Data.Id,
                        ApartmentId = suiteDto.ApartmentId
                    };
                    _suiteRepository.Insert(suite);
                }
            }

            return new SuccessResult();
        }

        public IResult Update(UpdateSuiteDto updateSuiteDto)
        {
            var suite = _suiteRepository.GetSuiteWithUser(updateSuiteDto.SuiteId);
            if (suite != null)
            {
                var newSuite = new Suite
                {
                    Id = updateSuiteDto.SuiteId,
                    UpdatedDate=DateTime.Now,
                    Block = updateSuiteDto.Block == default ? suite.Block : updateSuiteDto.Block,
                    Floor = updateSuiteDto.Floor == default ? suite.Floor : updateSuiteDto.Floor,
                    Type = updateSuiteDto.Type == default ? suite.Type : updateSuiteDto.Type,
                    NumberOfSuite = updateSuiteDto.NumberOfSuite == default ? suite.NumberOfSuite : updateSuiteDto.NumberOfSuite,
                    ApartmentId = updateSuiteDto.ApartmentId == default ? suite.ApartmentId : updateSuiteDto.ApartmentId,
                    Status = updateSuiteDto.Status == default ? suite.Status : updateSuiteDto.Status,
                    IsTenant = updateSuiteDto.IsTenant == default ? suite.IsTenant : updateSuiteDto.IsTenant,
                    UserId = updateSuiteDto.OwnerId == default ? suite.OwnerId : updateSuiteDto.OwnerId,
                };
                _suiteRepository.Update(newSuite);
                return new SuccessResult();
            }
            return new ErrorResult("Daire bulunamadı.");
        }

        public IResult UpdateRange(string type, int apartmentId)
        {
            var suites = _suiteRepository.GetAll(x => x.ApartmentId == apartmentId);
            var newlist = new List<Suite>();
            foreach(var item in suites) 
            {
                item.Type = type;
                newlist.Add(item);
            }

            _suiteRepository.UpdateRange(newlist);

            return new SuccessResult();
        }

        //private void CreateSuites(int numberOfFloor, int suiteOfFloorCount, string blockCode, string type)
        //{
        //    int k = 1;
        //    for (int i = 1; i <= numberOfFloor; i++)
        //    {
        //        for (int j = 1; j <= suiteOfFloorCount; j++)
        //        {
        //            var suite = new Suite
        //            {
        //                Block = blockCode,
        //                Floor = i,
        //                Type = type,
        //                NumberOfSuite = k++,
        //                Status = false,
        //                IsTenant = false,
        //                UserId = _userBusiness.GetUser(4).Data.Id
        //            };
        //            _suiteRepository.Insert(suite);
        //        }
        //    }
        //}
    }
}
