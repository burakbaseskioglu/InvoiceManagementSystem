using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Entity.Entities.Dto
{
    public class DuesDetailDto
    {
        public string User { get; set; }
        public int Suite { get; set; }
        public string Period { get; set; }
        public decimal Amount { get; set; }
    }
}
