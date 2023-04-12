using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Entity.Entities.Dto
{
    public class CardDto
    {
        public string CardOwner { get; set; }
        public string CardNumber { get; set; }
        public int ExpireMonth { get; set; }
        public int ExpireYear { get; set; }
        public int CvcCode { get; set; }
    }
}
