using InvoiceManagementSystemPaymentApi.Subscriber;
using Microsoft.Extensions.DependencyInjection;

namespace InvoiceManagementSystem.Listener
{
    public static class ServiceCollectionExtension
    {
        public static IServiceProvider AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IMessageSubscriber, MessageSubscriber>();
            serviceCollection.AddHttpClient();
            return serviceCollection.BuildServiceProvider();
        }
    }
}
