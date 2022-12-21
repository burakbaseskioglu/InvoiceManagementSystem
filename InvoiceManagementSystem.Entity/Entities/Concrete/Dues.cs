using InvoiceManagementSystem.Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Entity.Entities.Concrete
{
    public class Dues : BaseEntity
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }

    }
}
