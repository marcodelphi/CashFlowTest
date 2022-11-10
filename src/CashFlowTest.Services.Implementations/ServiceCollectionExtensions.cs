using CashFlowTest.Services.Abstractions.Services;
using CashFlowTest.Services.Implementations.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlowTest.Services.Implementations;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IExpenseCategoryService, ExpenseCategoryService>();
        services.AddScoped<IIncomeService, IncomeService>();
        services.AddScoped<IExpenseService, ExpenseService>();
        services.AddScoped<ICashFlowService, CashFlowService>();

        return services;
    }
}
