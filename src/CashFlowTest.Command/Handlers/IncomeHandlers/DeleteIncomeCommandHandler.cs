using CashFlowTest.Command.AbstractHandlers;
using CashFlowTest.Command.Abstractions.Commands.IncomeCommands;
using CashFlowTest.Command.Abstractions.Repositories;
using CashFlowTest.Domain.Model.Entities;
using CashFlowTest.Notifications.Notifications;
using MediatR;

namespace CashFlowTest.Command.Handlers.ExpenseCategoryHandlers;

internal sealed class DeleteIncomeCommandHandler : SimpleCommandHandler<DeleteIncomeCommand>
{
    private readonly IIncomeRepository _repository;

    public DeleteIncomeCommandHandler(IMediator mediator, IIncomeRepository repository): base(mediator) => _repository = repository;

    protected override async Task<Unit> HandleCommandAsync(DeleteIncomeCommand command, CancellationToken cancellationToken)
    {
        Income income = await _repository.GetAsync(command.Id, cancellationToken);

        if (income == null)
            await _mediator.Publish(new NoEntityFoundNotification(command.Id, nameof(Income)), cancellationToken);

        await _repository.DeleteAsync(command.Id, cancellationToken);

        await _mediator.Publish(new IncomeDeleteNotification(income.IncomeDate, income.Value), cancellationToken);

        return Unit.Value;
    }
}
