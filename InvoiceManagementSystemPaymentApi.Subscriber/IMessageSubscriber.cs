using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystemPaymentApi.Subscriber
{
    public interface IMessageSubscriber
    {
        void ListenQueue(string queueName, Action<string> actionMessage);
    }
}
