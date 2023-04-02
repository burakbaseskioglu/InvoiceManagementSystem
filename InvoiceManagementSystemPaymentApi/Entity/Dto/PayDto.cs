namespace InvoiceManagementSystemPaymentApi.Entity.Dto
{
    public class PayDto
    {
        public int BillId { get; set; }
        public string CardOwner { get; set; }
        public string CardNumber { get; set; }
        public int ExpireMonth { get; set; }
        public int ExpireYear { get; set; }
        public int CvcCode { get; set; }
    }
}
