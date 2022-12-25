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
    public interface IDuesBusiness
    {
        IResult Insert(InsertDuesDto insertDuesDto);
        IResult InsertRange(InsertDuesDto insertDuesDto);
    }
}
