using CashFlowTest.Domain.Model.Entities;

namespace CashFlowTest.Command.Abstractions.Repositories;

public interface IExpenseCategoryRepository: ICommandRepository<ExpenseCategory>
{
    Task<ExpenseCategory> UpdateAsync(Guid id, string newDescription, CancellationToken cancellationToken);
}