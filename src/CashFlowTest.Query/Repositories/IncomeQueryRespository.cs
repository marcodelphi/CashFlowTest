using CashFlowTest.Domain.Data;
using CashFlowTest.Domain.Model.Entities;
using CashFlowTest.Query.Abstractions.Repositories;

namespace CashFlowTest.Query.Repositories;

public class IncomeQueryRespository : BaseQueryRepository<Income>, IIncomeQueryRespository
{
    public IncomeQueryRespository(CashFlowTestDataContext context) : base(context)
    {
    }
}
