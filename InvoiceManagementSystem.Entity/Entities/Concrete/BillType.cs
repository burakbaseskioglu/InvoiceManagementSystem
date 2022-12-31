using InvoiceManagementSystem.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Entity.Entities.Concrete
{
    public class BillType : BaseEntity
    {
        public int Id { get; set; }
        public string Type { get; set; }
    }
}
