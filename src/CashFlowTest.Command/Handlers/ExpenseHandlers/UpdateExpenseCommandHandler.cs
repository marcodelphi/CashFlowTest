using CashFlowTest.Command.AbstractHandlers;
using CashFlowTest.Command.Abstractions.Commands.ExpenseCommands;
using CashFlowTest.Command.Abstractions.Repositories;
using CashFlowTest.Crosscutting.Constants;
using CashFlowTest.Domain.Model.Entities;
using FluentValidation;

namespace CashFlowTest.Command.Handlers.ExpenseHandlers;

internal sealed class UpdateExpenseCommandHandler : EntityValidationCommandHandler<UpdateExpenseCommand, Expense>
{
    private readonly IExpenseRepository _repository;

    public UpdateExpenseCommandHandler(IExpenseRepository respository)
    {
        _repository = respository;
    }

    protected override async Task<Expense> HandleValidatedCommandAsync(UpdateExpenseCommand command, CancellationToken cancellationToken)
        => await _repository.UpdateAsync(command, cancellationToken);

    protected override void SetupRules()
    {
        RuleFor(command => command.Description)
            .NotEmpty()
            .MaximumLength(DatabaseFieldsLengthConstants.INCOME_DESCRIPTION_MAX_LENGTH);

        RuleFor(command => command.Value)
            .GreaterThan(0);
    }
}
