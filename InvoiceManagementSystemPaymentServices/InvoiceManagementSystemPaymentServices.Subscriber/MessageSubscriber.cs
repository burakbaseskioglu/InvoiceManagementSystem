using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace InvoiceManagementSystemPaymentServices.Subscriber
{
    public class MessageSubscriber : IMessageSubscriber
    {
        public async Task ListenQueue<T>(string queueName, Action<T> actionMessage)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "payment", durable: false, exclusive: false, autoDelete: false, arguments: null);

                var consumer = new AsyncEventingBasicConsumer(channel);
                consumer.Received += async (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    var deserializeEntity = JsonConvert.DeserializeObject<T>(message);
                    actionMessage(deserializeEntity);
                    await Task.CompletedTask;
                    channel.BasicAck(ea.DeliveryTag, false);
                };
                channel.BasicConsume(queue: "payment", autoAck: true, consumer: consumer);
                await Task.CompletedTask;
            }
        }
    }
}
