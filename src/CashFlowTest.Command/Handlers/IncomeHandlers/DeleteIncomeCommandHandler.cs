using CashFlowTest.Command.AbstractHandlers;
using CashFlowTest.Command.Abstractions.Commands.IncomeCommands;
using CashFlowTest.Command.Abstractions.Repositories;
using MediatR;

namespace CashFlowTest.Command.Handlers.ExpenseCategoryHandlers;

internal sealed class DeleteIncomeCommandHandler : SimpleCommandHandler<DeleteIncomeCommand>
{
    private readonly IIncomeRepository _repository;

    public DeleteIncomeCommandHandler(IMediator mediator, IIncomeRepository repository): base(mediator) => _repository = repository;

    protected override async Task<Unit> HandleCommandAsync(DeleteIncomeCommand command, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(command.Id, cancellationToken);

        return Unit.Value;
    }
}
