using CashFlowTest.Domain.Data;
using CashFlowTest.Domain.Model.Entities;
using CashFlowTest.Query.Abstractions.Repositories;

namespace CashFlowTest.Query.Repositories;

public class ExpenseCategoryQueryRespository : BaseQueryRepository<ExpenseCategory>, IExpenseCategoryQueryRespository
{
    public ExpenseCategoryQueryRespository(CashFlowTestDataContext context) : base(context)
    {
    }
}
