using CashFlowTest.Domain.Data.CommandContext;
using CashFlowTest.Domain.Model.Entities;
using CashFlowTest.Query.Abstractions.Repositories;

namespace CashFlowTest.Query.Repositories;

public class ExpenseQueryRepository : BaseQueryRepository<Expense>, IExpenseQueryRepository
{
    public ExpenseQueryRepository(CashFlowTestDataContext context) : base(context)
    {
    }
}
