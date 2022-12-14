using CashFlowTest.Domain.Model.Adapters;
using CashFlowTest.Domain.Model.AdaptersContracts;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlowTest.Domain.Model;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAdapters(this IServiceCollection services)
    {
        services.AddScoped<IExpenseCategoryAdapter, ExpenseCategoryAdapter>();
        services.AddScoped<IIncomeAdapter, IncomeAdapter>();
        services.AddScoped<IExpenseAdapter, ExpenseAdapter>();
        return services;
    }
}
