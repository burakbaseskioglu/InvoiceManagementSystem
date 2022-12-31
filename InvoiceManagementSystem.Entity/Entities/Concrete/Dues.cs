using InvoiceManagementSystem.Core.Entity;
using InvoiceManagementSystem.Core.Enums;
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
        public bool IsPaid { get; set; }
        public int BillTypeId { get; set; }
        public BillType BillType { get; set; }
        public string BillingPeriod { get; set; }
        public decimal Amount { get; set; }
        public int SuiteId { get; set; }
        public Suite Suite { get; set; }
    }
}
