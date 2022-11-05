using CashFlowTest.Command.AbstractHandlers;
using CashFlowTest.Command.Abstractions.Commands.IncomeCommands;
using CashFlowTest.Command.Abstractions.Repositories;
using CashFlowTest.Crosscutting.Constants;
using CashFlowTest.Domain.Model.Entities;
using FluentValidation;

namespace CashFlowTest.Command.Handlers.IncomeHandlers;

internal sealed class AddIncomeCommandHandler : EntityValidationCommandHandler<AddIncomeCommand, Income>
{
    private readonly IIncomeRepository _repository;

    public AddIncomeCommandHandler(IIncomeRepository repository)
    {
        _repository = repository;
    }

    protected override async Task<Income> HandleValidatedCommandAsync(AddIncomeCommand command, CancellationToken cancellationToken)
    {
        return await _repository.AddAsync(new Income(command.Description, command.Value)
        {
            Note = command.Note,
            IncomeDate = command.IncomeDate
        }, cancellationToken);
    }

    protected override void SetupRules()
    {
        RuleFor(command => command.Description)
            .NotEmpty()
            .MaximumLength(DatabaseFieldsLengthConstants.INCOME_DESCRIPTION_MAX_LENGTH);

        RuleFor(command => command.Value)
            .GreaterThan(0);
    }
}
