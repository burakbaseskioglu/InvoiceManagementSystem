using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Core.Utilities.Service.HttpService
{
    public class HttpResult
    {
        public object data { get; set; }
        public string message { get; set; }
        public bool success { get; set; }
    }
}
