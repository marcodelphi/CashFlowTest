using CashFlowTest.Query.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlowTest.Query;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddQueryHandlers(this IServiceCollection services)
    {
        services.AddScoped<IMediator, Mediator>(provider => new Mediator(provider.GetService));
        services.RegisterQueryHandlersInAssembly();

        services.AddScoped<IExpenseCategoryQueryRespository, ExpenseCategoryQueryRespository>();
        return services;
    }

    private static void RegisterQueryHandlersInAssembly(this IServiceCollection services)
    {
        IEnumerable<(Type interfaceType, Type implementationType)> handlers = typeof(ServiceCollectionExtensions).Assembly.GetTypes()
            .Where(x => x.GetInterface(typeof(IRequestHandler<,>).FullName) != null && x.IsClass && !x.IsAbstract)
            .Select(x => (x.GetInterface(typeof(IRequestHandler<,>).FullName), x));
        foreach ((Type interfaceType, Type implementationType) in handlers)
            services.AddScoped(interfaceType, implementationType);
    }
}
