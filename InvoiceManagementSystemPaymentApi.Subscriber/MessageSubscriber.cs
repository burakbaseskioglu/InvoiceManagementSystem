using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace InvoiceManagementSystemPaymentApi.Subscriber
{
    public class MessageSubscriber : IMessageSubscriber
    {
        public void ListenQueue(string queueName, Action<string> actionMessage)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "payment", durable: false, exclusive: false, autoDelete: false, arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    actionMessage(message);
                };
                channel.BasicConsume(queue: "payment", autoAck: false, consumer: consumer);
            }
        }
    }
}
