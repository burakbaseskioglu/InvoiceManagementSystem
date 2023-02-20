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
using System.Transactions;
using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManagementSystem.Business.Concrete
{
    public class ApartmentBusiness : IApartmentBusiness
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly ISuiteBusiness _suiteBusiness;

        public ApartmentBusiness(IApartmentRepository apartmentRepository, ISuiteBusiness suiteBusiness)
        {
            _apartmentRepository = apartmentRepository;
            _suiteBusiness = suiteBusiness;
        }

        public IResult Delete(int apartmentId)
        {
            var apartment = _apartmentRepository.Get(x => x.Id == apartmentId);
            if (apartment != null)
            {
                apartment.IsActive = false;
                apartment.DeletedDate = DateTime.Now;
                _apartmentRepository.Update(apartment);
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IDataResult<List<ApartmentDto>> SearchByName(string apartmentName)
        {
            var getAllApartments = _apartmentRepository.GetAll(x => x.IsActive).Select(x => x);
            if (getAllApartments != null && !string.IsNullOrEmpty(apartmentName))
            {
                var apartments = from apt in getAllApartments
                                    where apt.Name.ToLower().Contains(apartmentName.ToLower())
                                    select new ApartmentDto
                                    {
                                        Name = apt.Name,
                                        NumberOfFloor = apt.NumberOfFloor,
                                        NumberOfSuite = apt.NumberOfSuite,
                                        Address = apt.Address,
                                        ApartmentNo = apt.ApartmentNo,
                                        BlockCode = apt.BlockCode,
                                        ManagementId = apt.ManagementId
                                    };
                return new SuccessDataResult<List<ApartmentDto>>(apartments.ToList());
            }
            return new ErrorDataResult<List<ApartmentDto>>("Apartman bulunamadı");
        }

        public IDataResult<List<ApartmentDto>> GetAll()
        {
            var getAllApartment = _apartmentRepository.GetAll(x => x.IsActive).ToList();
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
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    var getApartment = _apartmentRepository.Get(x => x.ApartmentNo == apartmentDto.ApartmentNo);
                    if (getApartment == null)
                    {
                        var apartment = new Apartment
                        {
                            IsActive = true,
                            CreatedDate = DateTime.Now,
                            Name = apartmentDto.Name,
                            NumberOfFloor = apartmentDto.NumberOfFloor,
                            NumberOfSuite = apartmentDto.NumberOfSuite,
                            ManagementId = apartmentDto.ManagementId,
                            BlockCode = apartmentDto.BlockCode,
                            ApartmentNo = apartmentDto.ApartmentNo,
                            Address = apartmentDto.Address,
                        };
                        _apartmentRepository.Insert(apartment);
                        _suiteBusiness.InsertRange(new InsertRangeSuiteDto
                        {
                            BlockCode = apartmentDto.BlockCode,
                            NumberOfFloor = apartmentDto.NumberOfFloor,
                            SuiteOfFloorCount = apartmentDto.SuiteOfFloorCount,
                            Type = apartmentDto.SuiteType,
                            ApartmentId = apartment.Id
                        });
                        scope.Complete();
                        return new SuccessResult("Apartman ve daireler oluşturuldu.");
                    }
                    return new ErrorResult("Eklemeye çalıştığınız apartman zaten mevcut");
                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    return new ErrorResult($"Bir hata oluştu: {ex.Message}");
                }
            }
        }

        public IResult Update(ApartmentDto apartmentDto)
        {
            var apartment = _apartmentRepository.Get(x => x.Name == apartmentDto.Name && x.IsActive);
            if (apartment != null)
            {
                apartment.UpdatedDate = DateTime.Now;
                apartment.Name = apartmentDto.Name;
                apartment.ManagementId = apartmentDto.ManagementId;
                apartment.NumberOfSuite = apartmentDto.NumberOfSuite;
                apartment.NumberOfFloor = apartmentDto.NumberOfFloor;
                apartment.Address = apartmentDto.Address;
                _apartmentRepository.Update(apartment);

                _suiteBusiness.UpdateRange(apartmentDto.SuiteType, apartment.Id);

                return new SuccessResult();
            }
            return new ErrorResult("Bir hata oluştu.");
        }

        public IDataResult<ApartmentDto> GetApartmentById(int apartmentId)
        {
            var apartment = _apartmentRepository.Get(x => x.Id == apartmentId && x.IsActive);
            if (apartment != null)
            {
                return new SuccessDataResult<ApartmentDto>(new ApartmentDto
                {
                    Name = apartment.Name,
                    ApartmentNo = apartment.ApartmentNo,
                    BlockCode = apartment.BlockCode,
                    Address = apartment.Address,
                    NumberOfFloor = apartment.NumberOfFloor,
                });
            }
            return new ErrorDataResult<ApartmentDto>("Apartman bulunamadı.");
        }
    }
}
