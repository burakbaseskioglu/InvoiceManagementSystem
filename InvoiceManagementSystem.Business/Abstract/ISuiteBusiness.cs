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
    public interface ISuiteBusiness
    {
        IResult Insert(CreateSuiteDto createSuiteDto);
        IResult InsertRange(InsertRangeSuiteDto suiteDto);
        IResult Update(UpdateSuiteDto updateSuiteDto);
        IResult Delete(int suiteId);
        IDataResult<List<SuiteDto>> GetAll();
        IDataResult<SuiteDto> GetById(int suiteId);
        IResult UpdateRange(string type, int apartmentId);
        IResult AssignUser(int userId, int suiteId);
    }
}
