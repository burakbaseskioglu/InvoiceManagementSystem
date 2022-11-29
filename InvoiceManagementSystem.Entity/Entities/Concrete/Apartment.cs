using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Entity.Entities.Concrete
{
    public class Apartment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfFloor { get; set; }
        public int NumberOfSuite { get; set; }
        public int ManagementId { get; set; }
        public string BlockCode { get; set; }
        public string Address { get; set; }
        public int ApartmentNo { get; set; }
    }
}
