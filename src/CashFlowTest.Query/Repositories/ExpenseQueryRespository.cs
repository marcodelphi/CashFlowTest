using CashFlowTest.Domain.Data;
using CashFlowTest.Domain.Model.Entities;
using CashFlowTest.Query.Abstractions.Repositories;

namespace CashFlowTest.Query.Repositories;

public class ExpenseQueryRespository : BaseQueryRepository<Expense>, IExpenseQueryRespository
{
    public ExpenseQueryRespository(CashFlowTestDataContext context) : base(context)
    {
    }
}
