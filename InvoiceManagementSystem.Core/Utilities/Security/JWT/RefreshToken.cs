using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Core.Utilities.Security.JWT
{
    public class RefreshToken
    {
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
