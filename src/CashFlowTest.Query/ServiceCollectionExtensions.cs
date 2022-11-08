using CashFlowTest.Query.Abstractions.Repositories;
using CashFlowTest.Query.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlowTest.Query;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddQueryHandlers(this IServiceCollection services)
    {
        services.AddMediatR(typeof(ServiceCollectionExtensions).Assembly);

        services.AddScoped<IExpenseCategoryQueryRespository, ExpenseCategoryQueryRespository>();

        services.AddScoped<IIncomeQueryRespository, IncomeQueryRespository>();

        services.AddScoped<IExpenseQueryRespository, ExpenseQueryRespository>();

        return services;
    }
}
