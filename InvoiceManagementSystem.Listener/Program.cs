using InvoiceManagementSystem.Listener;
using InvoiceManagementSystemPaymentApi.Subscriber;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

Console.WriteLine("Hello, World!");

var services = new ServiceCollection();
//var serviceProvider = services.AddSingleton<IMessageSubscriber, MessageSubscriber>().BuildServiceProvider();
//var messageSubscriber = serviceProvider.GetRequiredService<IMessageSubscriber>();

//var serviceProvider1 = services.AddSingleton<IPaymentBusiness, PaymentBusiness>();
//var insertCouchbase = serviceProvider1.BuildServiceProvider().GetRequiredService<IPaymentBusiness>();

Thread.Sleep(10000);
var test = services.AddServices();

//var messageSubscriber = serviceProvider.GetRequiredService<IMessageSubscriber>();

var messageSubscriber = test.GetRequiredService<IMessageSubscriber>();
var httpClientFactory = test.GetRequiredService<IHttpClientFactory>();
var httpClient = httpClientFactory.CreateClient();

messageSubscriber.ListenQueue("payment", (message) =>
{
    //var payment = JsonConvert.DeserializeObject<Payment>(message);
    httpClient.PostAsync("http://localhost:44381/api/Payment/Insert", PostRequest(message));
});

static StringContent PostRequest(string json)
{
    var content = new StringContent(json, Encoding.UTF8, "application/json");
    return content;
}

Console.ReadLine();