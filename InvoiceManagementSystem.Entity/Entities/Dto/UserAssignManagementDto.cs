using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Entity.Entities.Dto
{
    public class UserAssignManagementDto
    {
        public int UserId { get; set; }
        public int SuiteId { get; set; }
        public bool IsManagementApprove { get; set; }
    }
}
