using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Entity.Entities.Concrete
{
    public class Suite
    {
        public int Id { get; set; }
        public string Block { get; set; }
        public int Floor { get; set; }
        public string Type { get; set; }
        public int NumberOfSuite { get; set; }
        public bool Status { get; set; }
        public bool IsTenant { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
