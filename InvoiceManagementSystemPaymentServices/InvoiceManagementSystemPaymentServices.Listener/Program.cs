using InvoiceManagementSystem.Listener;
using InvoiceManagementSystemPaymentServices.Listener;
using InvoiceManagementSystemPaymentServices.Subscriber;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;

var serviceCollection = new ServiceCollection();
var services = serviceCollection.AddServices();

var messageSubscriber = services.GetRequiredService<IMessageSubscriber>();
var httpClientFactory = services.GetRequiredService<IHttpClientFactory>();
var httpClient = httpClientFactory.CreateClient("paymentApi");
//httpClient.DefaultRequestHeaders.ConnectionClose = true;

//messageSubscriber.ListenQueue("payment", async (message) =>
//{
//    //var payment = JsonConvert.DeserializeObject<Payment>(message);
//    var payment = JsonConvert.SerializeObject(message);
//    StringContent content = new StringContent(payment.ToString(), Encoding.UTF8, "application/json");
//    var result = httpClient.PostAsync("/api/Payment/insert", content).GetAwaiter().GetResult();
//});


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
        //actionMessage(deserializeEntity);

        var jsonData = JsonConvert.SerializeObject(deserializeEntity);
        StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var result = httpClient.PostAsync("/api/Payment/insert", content).GetAwaiter().GetResult();

        //await Task.CompletedTask;
        //channel.BasicAck(ea.DeliveryTag, false);
    };
    channel.BasicConsume(queue: "payment", autoAck: true, consumer: consumer);
    //await Task.CompletedTask;
    Console.ReadLine();
}