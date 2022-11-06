using CashFlowTest.Command.Abstractions.Commands.ExpenseCommands;
using CashFlowTest.Crosscutting.DTOs;
using CashFlowTest.Domain.Model.AdaptersContracts;
using CashFlowTest.Domain.Model.Entities;
using CashFlowTest.Query.Abstractions.Queries.ExpenseQueries;
using CashFlowTest.Services.Abstractions.Services;
using CashFlowTest.Services.Implementations.Services.Core;
using MediatR;

namespace CashFlowTest.Services.Implementations.Services;

public class ExpenseService : BaseCrudService<Expense, ExpenseDto, AddExpenseCommand, UpdateExpenseCommand, DeleteExpenseCommand>, IExpenseService
{
    private readonly IExpenseAdapter _adapter;

    public ExpenseService(IMediator mediator, IExpenseAdapter adapter) : base(mediator)
    {
        _adapter = adapter;
    }

    protected override ExpenseDto ToDto(Expense expense) => _adapter.ToDto(expense);

    public async Task<ExpenseDto[]> GetAllIncomesAsync(CancellationToken cancellationToken)
    {
        Expense[] expenses = await _mediator.Send(new GetExpensesQuery(), cancellationToken);

        return expenses.Select(income => ToDto(income)).ToArray();
    }

    public async Task<ExpenseDto[]> GetAllExpensesAsync(CancellationToken cancellationToken)
    {
        Expense[] expenses = await _mediator.Send(new GetExpensesQuery(), cancellationToken);

        return expenses.Select(expense => ToDto(expense)).ToArray();
    }
}
