using CashFlowTest.Domain.Model.Entities;

namespace CashFlowTest.Query.Repositories;

internal interface IExpenseCategoryQueryRespository: IQueryRepository<ExpenseCategory>
{
    Task<ExpenseCategory[]> GetAllAsync(CancellationToken cancellationToken);
}