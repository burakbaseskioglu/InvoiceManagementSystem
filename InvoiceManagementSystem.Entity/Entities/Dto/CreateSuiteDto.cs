using InvoiceManagementSystem.Entity.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Entity.Entities.Dto
{
    public class CreateSuiteDto
    {
        public string Block { get; set; }
        public int Floor { get; set; }
        public int DoorNumber { get; set; }
        public string Type { get; set; }
        public bool Status { get; set; }
        public bool IsTenant { get; set; }
        public int ApartmentId { get; set; }
        public int UserId { get; set; }
    }
}
