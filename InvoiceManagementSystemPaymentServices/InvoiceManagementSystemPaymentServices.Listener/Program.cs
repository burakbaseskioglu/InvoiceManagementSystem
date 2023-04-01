using InvoiceManagementSystem.Listener;
using InvoiceManagementSystemPaymentServices.Listener;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var serviceCollection = new ServiceCollection();
var services = serviceCollection.AddServices();

var httpClientFactory = services.GetRequiredService<IHttpClientFactory>();
var httpClient = httpClientFactory.CreateClient("paymentApi");


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
        var deserializeEntity = JsonConvert.DeserializeObject<Payment>(message);
        Console.WriteLine($"Received {deserializeEntity.Id} - {deserializeEntity.SuiteId}");
        var jsonData = JsonConvert.SerializeObject(deserializeEntity);
        StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var result = httpClient.PostAsync("/api/Payment/insert", content).GetAwaiter().GetResult();
    };
    channel.BasicConsume(queue: "payment", autoAck: true, consumer: consumer);
    Console.ReadLine();
}