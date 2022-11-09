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

        services.AddScoped<IExpenseCategoryQueryRepository, ExpenseCategoryQueryRepository>();

        services.AddScoped<IIncomeQueryRepository, IncomeQueryRepository>();

        services.AddScoped<IExpenseQueryRepository, ExpenseQueryRepository>();

        //services.AddScoped<ICashFlowSummaryRepository, CashFlowSummaryRepository>();

        return services;
    }
}
