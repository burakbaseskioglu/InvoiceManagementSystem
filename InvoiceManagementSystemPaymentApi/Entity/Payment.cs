using Couchbase.Linq;

namespace InvoiceManagementSystemPaymentApi.Entity
{
    [CouchbaseCollection("_default", "Payment")]
    public class Payment
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
