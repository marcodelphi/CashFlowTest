using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlowTest.Notifications;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddNotificationHandlers(this IServiceCollection services)
    {
        services.AddMediatR(typeof(ServiceCollectionExtensions).Assembly);

        return services;
    }

}
