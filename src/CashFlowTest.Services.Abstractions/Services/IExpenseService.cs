using CashFlowTest.Command.Abstractions.Commands.ExpenseCommands;
using CashFlowTest.Crosscutting.DTOs;
using CashFlowTest.Domain.Model.Entities;
using CashFlowTest.Services.Abstractions.Services.Core;

namespace CashFlowTest.Services.Abstractions.Services;

public interface IExpenseService : IBaseCrudService<Expense, ExpenseDto, AddExpenseCommand, UpdateExpenseCommand, DeleteExpenseCommand>
{
    Task<ExpenseDto[]> GetAllExpensesAsync(CancellationToken cancellationToken);
}
