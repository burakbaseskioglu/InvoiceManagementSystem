using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystemPaymentServices.Subscriber
{
    public interface IMessageSubscriber
    {
        Task ListenQueue<T>(string queueName, Action<T> actionMessage);
    }
}
