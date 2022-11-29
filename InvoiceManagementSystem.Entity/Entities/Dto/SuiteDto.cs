using InvoiceManagementSystem.Entity.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Entity.Entities.Dto
{
    public class SuiteDto
    {
        public string Block { get; set; }
        public int Floor { get; set; }
        public string Type { get; set; }
        public int NumberOfSuite { get; set; }
        public bool Status { get; set; }
        public bool IsTenant { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public long IdentityNumber { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string LicensePlate { get; set; }
    }
}
