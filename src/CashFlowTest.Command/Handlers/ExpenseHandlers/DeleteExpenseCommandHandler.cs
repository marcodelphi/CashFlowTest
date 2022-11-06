using CashFlowTest.Command.AbstractHandlers;
using CashFlowTest.Command.Abstractions.Commands.ExpenseCommands;
using CashFlowTest.Command.Abstractions.Repositories;
using MediatR;

namespace CashFlowTest.Command.Handlers.ExpenseHandlers;

internal sealed class DeleteExpenseCommandHandler : SimpleCommandHandler<DeleteExpenseCommand>
{
    private readonly IExpenseRepository _repository;

    public DeleteExpenseCommandHandler(IExpenseRepository respository) => _repository = respository;

    protected override async Task<Unit> HandleCommandAsync(DeleteExpenseCommand command, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(command.Id, cancellationToken);

        return Unit.Value;
    }
}
