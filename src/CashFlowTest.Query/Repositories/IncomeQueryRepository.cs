using CashFlowTest.Domain.Data.CommandContext;
using CashFlowTest.Domain.Model.Entities;
using CashFlowTest.Query.Abstractions.Repositories;

namespace CashFlowTest.Query.Repositories;

public class IncomeQueryRepository : BaseQueryRepository<Income>, IIncomeQueryRepository
{
    public IncomeQueryRepository(CashFlowTestDataContext context) : base(context)
    {
    }
}
