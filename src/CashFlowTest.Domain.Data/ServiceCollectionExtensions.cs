using CashFlowTest.Crosscutting;
using CashFlowTest.Domain.Data.CommandContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlowTest.Domain.Data;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCashFlowTestDataContext(this IServiceCollection services)
    {
        services.AddDbContextPool<CashFlowTestDataContext>(options => options.UseInMemoryDatabase(DataBaseConstants.CASH_FLOW_TEST_COMMAND_DATABASE_NAME));
        services.AddDbContextPool<CashFlowTestQueryContext>(options => options.UseInMemoryDatabase(DataBaseConstants.CASH_FLOW_TEST_QUERY_DATABASE_NAME));
        return services;
    }
}
