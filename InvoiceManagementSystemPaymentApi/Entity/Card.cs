namespace InvoiceManagementSystemPaymentApi.Entity
{
    public class Card
    {
        public int Id { get; set; }
        public string CardOwner { get; set; }
        public string CardNumber { get; set; }
        public int ExpireMonth { get; set; }
        public int ExpireYear { get; set; }
        public int CvcCode { get; set; }
        public decimal Balance { get; set; }
    }
}
