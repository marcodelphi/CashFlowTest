using CashFlowTest.Command.AbstractHandlers;
using CashFlowTest.Command.Abstractions.Commands.ExpenseCategoryCommands;
using CashFlowTest.Command.Abstractions.Repositories;
using MediatR;

namespace CashFlowTest.Command.Handlers.ExpenseCategoryHandlers;

internal sealed class DeleteExpenseCategoryCommandHandler : SimpleCommandHandler<DeleteExpenseCategoryCommand>
{
    private readonly IExpenseCategoryRepository _repository;

    public DeleteExpenseCategoryCommandHandler(IMediator mediator, IExpenseCategoryRepository respository): base(mediator) => _repository = respository;

    protected override async Task<Unit> HandleCommandAsync(DeleteExpenseCategoryCommand command, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(command.Id, cancellationToken);

        return Unit.Value;
    }
}
