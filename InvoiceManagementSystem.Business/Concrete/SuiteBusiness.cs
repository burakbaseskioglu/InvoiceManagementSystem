using InvoiceManagementSystem.Business.Abstract;
using InvoiceManagementSystem.Core.Utilities.Result;
using InvoiceManagementSystem.DataAccess.Abstract;
using InvoiceManagementSystem.Entity.Entities.Concrete;
using InvoiceManagementSystem.Entity.Entities.Dto;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
using System.Runtime.CompilerServices;

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

        public IDataResult<List<SuiteDto>> GetAll()
        {
            var suites = _suiteRepository.GetAllSuitesWithUsers();
            if (suites != null)
            {
                return new SuccessDataResult<List<SuiteDto>>(suites);
            }
            return new ErrorDataResult<List<SuiteDto>>("Daire listesin bulunamadı");
        }

        public IResult Insert(Suite suite)
        {
            throw new NotImplementedException();
        }

        public IResult InsertRange(CreateSuiteDto suiteDto)
        {
            CreateSuites(suiteDto.NumberOfFloor, suiteDto.SuiteOfFloorCount, suiteDto.BlockCode, suiteDto.Type);
            return new SuccessResult();
        }

        private void CreateSuites(int numberOfFloor, int suiteOfFloorCount, string blockCode, string type)
        {
            int k = 1;
            for (int i = 1; i <= numberOfFloor; i++)
            {
                for (int j = 1; j <= suiteOfFloorCount; j++)
                {
                    _suiteRepository.Insert(new Suite
                    {
                        Block = blockCode,
                        Floor = i,
                        Type = type,
                        NumberOfSuite = k++,
                        Status = false,
                        IsTenant = false,
                        SuiteOwnerId = _userBusiness.GetUser(1).Data.Id,
                        User = _userBusiness.GetUser(1).Data
                    });
                }
            }
        }
    }
}
