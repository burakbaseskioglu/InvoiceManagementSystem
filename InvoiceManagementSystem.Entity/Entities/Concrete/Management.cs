using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Entity.Entities.Concrete
{
    public class Management
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
