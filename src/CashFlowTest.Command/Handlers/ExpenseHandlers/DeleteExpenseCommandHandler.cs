using CashFlowTest.Command.AbstractHandlers;
using CashFlowTest.Command.Abstractions.Commands.ExpenseCommands;
using CashFlowTest.Command.Abstractions.Repositories;
using CashFlowTest.Domain.Model.Entities;
using CashFlowTest.Notifications.Notifications;
using MediatR;

namespace CashFlowTest.Command.Handlers.ExpenseHandlers;

internal sealed class DeleteExpenseCommandHandler : SimpleCommandHandler<DeleteExpenseCommand>
{
    private readonly IExpenseRepository _repository;

    public DeleteExpenseCommandHandler(IMediator mediator, IExpenseRepository repository): base(mediator) => _repository = repository;

    protected override async Task<Unit> HandleCommandAsync(DeleteExpenseCommand command, CancellationToken cancellationToken)
    {
        Expense expense = await _repository.GetAsync(command.Id, cancellationToken);

        if (expense == null)
            await _mediator.Publish(new NoEntityFoundNotification(command.Id, nameof(Expense)), cancellationToken);

        await _repository.DeleteAsync(command.Id, cancellationToken);

        await _mediator.Publish(new ExpenseDeleteNotification(expense.ExpenseDate, expense.Value), cancellationToken);

        return Unit.Value;
    }
}
