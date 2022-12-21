using InvoiceManagementSystem.Core.Utilities.Result;
using InvoiceManagementSystem.Entity.Entities.Concrete;
using InvoiceManagementSystem.Entity.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Business.Abstract
{
    public interface IApartmentBusiness
    {
        IResult Insert(ApartmentDto apartmentDto);
        IResult Delete(int apartmentId);
        IResult Update(ApartmentDto apartmentDto);
        IDataResult<List<ApartmentDto>> GetAll();
        IDataResult<ApartmentDto> GetApartmentByName(string apartmentName);
        IDataResult<ApartmentDto> GetApartmentById(int apartmentId);
    }
}
