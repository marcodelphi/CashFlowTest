using CashFlowTest.Domain.Data.CommandContext;
using CashFlowTest.Domain.Model.Entities;
using CashFlowTest.Query.Abstractions.Repositories;

namespace CashFlowTest.Query.Repositories;

public class ExpenseCategoryQueryRepository : BaseQueryRepository<ExpenseCategory>, IExpenseCategoryQueryRepository
{
    public ExpenseCategoryQueryRepository(CashFlowTestDataContext context) : base(context)
    {
    }
}
