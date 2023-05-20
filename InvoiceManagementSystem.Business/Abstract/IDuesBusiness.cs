using InvoiceManagementSystem.Core.Utilities.Result;
using InvoiceManagementSystem.Entity.Entities.Concrete;
using InvoiceManagementSystem.Entity.Entities.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Business.Abstract
{
    public interface IDuesBusiness
    {
        IResult Insert(InsertDuesDto insertDuesDto);
        IResult InsertRange(InsertRangeDuesDto insertRangeDuesDto);
        IDataResult<List<DuesDto>> PaidDebtList();
        IDataResult<List<DuesDto>> UnpaidDebtList();
        IResult Update(InsertDuesDto insertDuesDto);
        IResult Delete(int duesId);
        IDataResult<List<DuesDto>> GetAll();
        IResult PayTheDue(DuesPaymentDto duesPaymentDto);
        Task<IResult> PayTheDueCard(CardDto cardDto, int billId);
        IDataResult<Stream> ExcelTest();
    }
}
