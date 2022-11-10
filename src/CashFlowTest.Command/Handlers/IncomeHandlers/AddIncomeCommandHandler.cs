using CashFlowTest.Command.AbstractHandlers;
using CashFlowTest.Command.Abstractions.Commands.IncomeCommands;
using CashFlowTest.Command.Abstractions.Repositories;
using CashFlowTest.Crosscutting.Constants;
using CashFlowTest.Domain.Model.Entities;
using CashFlowTest.Notifications.Notifications;
using FluentValidation;
using MediatR;

namespace CashFlowTest.Command.Handlers.IncomeHandlers;

internal sealed class AddIncomeCommandHandler : EntityValidationCommandHandler<AddIncomeCommand, Income>
{
    private readonly IIncomeRepository _repository;

    public AddIncomeCommandHandler(IMediator mediator, IIncomeRepository repository) : base(mediator) => _repository = repository;

    protected override async Task<Income> HandleValidatedCommandAsync(AddIncomeCommand command, CancellationToken cancellationToken)
    {
        Income income = new Income(command.Description, command.Value)
        {
            Note = command.Note,
        };

        income.SetIncomeDate(command.IncomeDate);

        income = await _repository.AddAsync(income, cancellationToken);

        await _mediator.Publish(new IncomeAddNotification(income.Id, income.Description, income.Note, income.Value, income.CreatedDate, income.IncomeDate), cancellationToken);

        return income;
    }

    protected override void SetupRules()
    {
        RuleFor(command => command.Description)
            .NotEmpty()
            .MaximumLength(DatabaseFieldsLengthConstants.INCOME_DESCRIPTION_MAX_LENGTH);

        RuleFor(command => command.Note)
            .MaximumLength(DatabaseFieldsLengthConstants.INCOME_NOTE_MAX_LENGTH);

        RuleFor(command => command.Value)
            .GreaterThan(0);
    }
}
