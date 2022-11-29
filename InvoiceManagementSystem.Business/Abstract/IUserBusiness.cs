using InvoiceManagementSystem.Core.Utilities.Result;
using InvoiceManagementSystem.Entity.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Business.Abstract
{
    public interface IUserBusiness
    {
        IDataResult<User> GetUser(int userId);
    }
}
