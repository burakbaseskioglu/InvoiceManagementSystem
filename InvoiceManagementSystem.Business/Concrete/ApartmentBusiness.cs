using InvoiceManagementSystem.Business.Abstract;
using InvoiceManagementSystem.Entity.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoiceManagementSystem.DataAccess.Abstract;
using InvoiceManagementSystem.Entity.Entities.Dto;
using InvoiceManagementSystem.Core.Utilities.Result;

namespace InvoiceManagementSystem.Business.Concrete
{
    public class ApartmentBusiness : IApartmentBusiness
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly ISuiteBusiness _suiteBusiness;
        private readonly IUserBusiness _userBusiness;

        public ApartmentBusiness(IApartmentRepository apartmentRepository, ISuiteBusiness suiteBusiness, IUserBusiness userBusiness)
        {
            _apartmentRepository = apartmentRepository;
            _suiteBusiness = suiteBusiness;
            _userBusiness = userBusiness;
        }

        public IResult Delete(int apartmentId)
        {
            var apartment = _apartmentRepository.Get(x => x.Id == apartmentId);
            if (apartment != null)
            {
                _apartmentRepository.Delete(apartment);
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IDataResult<ApartmentDto> GetApartmentByName(string apartmentName)
        {
            var apartment = _apartmentRepository.Get(x => x.Name.ToLower() == apartmentName.ToLower());
            if (apartment != null)
            {
                return new SuccessDataResult<ApartmentDto>(
                    new ApartmentDto
                    {
                        Name = apartment.Name,
                        NumberOfFloor = apartment.NumberOfFloor,
                        NumberOfSuite = apartment.NumberOfSuite,
                        Address = apartment.Address,
                        ApartmentNo = apartment.ApartmentNo,
                        BlockCode = apartment.BlockCode,
                        ManagementId = apartment.ManagementId
                    });
            }
            return new ErrorDataResult<ApartmentDto>("Apartman bulunamadı");
        }

        public IDataResult<List<ApartmentDto>> GetAll()
        {
            var getAllApartment = _apartmentRepository.GetAll().ToList();
            if (getAllApartment != null)
            {
                var apartmentList = new List<ApartmentDto>();
                foreach (var apartment in getAllApartment)
                {
                    apartmentList.Add(new ApartmentDto()
                    {
                        Name = apartment.Name,
                        NumberOfFloor = apartment.NumberOfFloor,
                        NumberOfSuite = apartment.NumberOfSuite,
                        ApartmentNo = apartment.ApartmentNo,
                        Address = apartment.Address,
                        BlockCode = apartment.BlockCode,
                    });
                }
                return new SuccessDataResult<List<ApartmentDto>>(apartmentList);
            }
            return new ErrorDataResult<List<ApartmentDto>>("Apartman listesi bulunamadı.");
        }

        public IResult Insert(ApartmentDto apartmentDto)
        {
            var getApartment = _apartmentRepository.Get(x => x.ApartmentNo == apartmentDto.ApartmentNo);
            if (getApartment == null)
            {
                var apartment = new Apartment
                {
                    Name = apartmentDto.Name,
                    NumberOfFloor = apartmentDto.NumberOfFloor,
                    NumberOfSuite = apartmentDto.NumberOfSuite,
                    ManagementId = apartmentDto.ManagementId,
                    BlockCode = apartmentDto.BlockCode,
                    ApartmentNo = apartmentDto.ApartmentNo,
                    Address = apartmentDto.Address,
                };
                _apartmentRepository.Insert(apartment);
                _suiteBusiness.InsertRange(new CreateSuiteDto
                {
                    BlockCode = apartmentDto.BlockCode,
                    NumberOfFloor = apartmentDto.NumberOfFloor,
                    SuiteOfFloorCount = apartmentDto.SuiteOfFloorCount,
                    Type = apartmentDto.SuiteType
                });
                return new SuccessResult("Apartman ve daireler oluşturuldu.");
            }
            return new ErrorResult("Eklemeye çalıştığınız apartman zaten mevcut");
        }

        public IResult Update(ApartmentDto apartmentDto)
        {
            var apartment = _apartmentRepository.Get(x => x.Name == apartmentDto.Name);
            if (apartment != null)
            {
                apartment.Name = apartmentDto.Name;
                apartment.ManagementId = apartmentDto.ManagementId;
                apartment.NumberOfSuite = apartmentDto.NumberOfSuite;
                apartment.NumberOfFloor = apartmentDto.NumberOfFloor;
                _apartmentRepository.Update(apartment);
                return new SuccessResult();
            }
            return new ErrorResult("Bir hata oluştu.");
        }
    }
}
