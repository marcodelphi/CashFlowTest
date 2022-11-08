using CashFlowTest.Command.Abstractions.Repositories;
using CashFlowTest.Command.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlowTest.Command;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCommandHandlers(this IServiceCollection services)
    {
        services.AddMediatR(typeof(ServiceCollectionExtensions).Assembly);

        services.AddScoped<IExpenseCategoryRepository, ExpenseCategoryRepository>();

        services.AddScoped<IIncomeRepository, IncomeRepository>();

        services.AddScoped<IExpenseRepository, ExpenseRepository>();
        return services;
    }

}
