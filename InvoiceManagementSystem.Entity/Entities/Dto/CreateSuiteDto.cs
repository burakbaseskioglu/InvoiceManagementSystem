using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Entity.Entities.Dto
{
    public class CreateSuiteDto
    {
        public int NumberOfFloor { get; set; }
        public int SuiteOfFloorCount { get; set; }
        public string BlockCode { get; set; }
        public string Type { get; set; }
    }
}
