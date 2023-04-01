using Microsoft.Extensions.DependencyInjection;

namespace InvoiceManagementSystem.Listener
{
    public static class ServiceCollectionExtension
    {
        public static IServiceProvider AddServices(this IServiceCollection serviceCollection)
        {
            //serviceCollection.AddSingleton<IMessageSubscriber, MessageSubscriber>();

            serviceCollection.AddHttpClient("paymentApi", (client) =>
            {
                client.BaseAddress = new Uri("https://localhost:44381");
            });
            //serviceCollection.AddHttpClient();
            return serviceCollection.BuildServiceProvider();
        }
    }
}
