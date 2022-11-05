using CashFlowTest.Crosscutting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlowTest.Domain.Data;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCashFlowTestDataContext(this IServiceCollection services)
    {
        services.AddDbContext<CashFlowTestDataContext>(options => options.UseInMemoryDatabase(DataBaseConstants.CASH_FLOW_TEST_DATABASE_NAME));
        return services;
    }
}
