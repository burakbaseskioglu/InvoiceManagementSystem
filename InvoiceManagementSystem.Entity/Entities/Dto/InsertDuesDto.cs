﻿using InvoiceManagementSystem.Entity.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Entity.Entities.Dto
{
    public class InsertDuesDto
    {
        public int Type { get; set; }
        public string BillingPeriod { get; set; }
        public decimal Amount { get; set; }
        public int SuiteId { get; set; }
    }
}
