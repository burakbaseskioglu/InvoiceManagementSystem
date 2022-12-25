using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Entity.Entities.Dto
{
    public class UserInsertDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public long IdentityNumber { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string LicensePlate { get; set; }
        public bool IsManagement { get; set; }
    }
}
