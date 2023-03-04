using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace InvoiceManagementSystem.Publishers
{
    public class MessagePublisher : IMessagePublisher
    {
        public void Publish<T>(T message)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue:"payment", durable:false, exclusive:false, autoDelete:false, arguments:null);

                var serializeMessage = JsonConvert.SerializeObject(message);
                var messageBody = Encoding.UTF8.GetBytes(serializeMessage);

                channel.BasicPublish(exchange: "", "payment", basicProperties: null, messageBody);
            }
        }
    }
}
