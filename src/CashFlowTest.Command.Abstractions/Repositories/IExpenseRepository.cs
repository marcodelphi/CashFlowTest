using CashFlowTest.Command.Abstractions.Commands.ExpenseCommands;
using CashFlowTest.Command.Abstractions.Repositories.Core;
using CashFlowTest.Domain.Model.Entities;

namespace CashFlowTest.Command.Abstractions.Repositories;

public interface IExpenseRepository : ICommandRepository<Expense>
{
    Task<Expense> UpdateAsync(UpdateExpenseCommand command, CancellationToken cancellationToken);
}