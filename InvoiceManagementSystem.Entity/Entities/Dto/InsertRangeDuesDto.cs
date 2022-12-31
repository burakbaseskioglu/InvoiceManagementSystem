using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Entity.Entities.Dto
{
    public class InsertRangeDuesDto
    {
        public bool IsPaid { get; set; }
        public int Type { get; set; }
        public string BillingPeriod { get; set; }
        public decimal Amount { get; set; }
        public int ApartmentId { get; set; }
    }
}
