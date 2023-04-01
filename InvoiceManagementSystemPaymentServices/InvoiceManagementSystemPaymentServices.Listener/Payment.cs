namespace InvoiceManagementSystemPaymentServices.Listener
{
    public class Payment
    {
        public int Id { get; set; }
        public string BillTypeId { get; set; }
        public string BillingPeriod { get; set; }
        public decimal Amount { get; set; }
        public int SuiteId { get; set; }
        public bool IsPaid { get; set; } = false;
    }
}
