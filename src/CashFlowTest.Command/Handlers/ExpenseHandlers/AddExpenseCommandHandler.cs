using CashFlowTest.Command.AbstractHandlers;
using CashFlowTest.Command.Abstractions.Commands.ExpenseCommands;
using CashFlowTest.Command.Abstractions.Repositories;
using CashFlowTest.Crosscutting.Constants;
using CashFlowTest.Domain.Model.Entities;
using FluentValidation;

namespace CashFlowTest.Command.Handlers.ExpenseHandlers;

internal sealed class AddExpenseCommandHandler : EntityValidationCommandHandler<AddExpenseCommand, Expense>
{
    private readonly IExpenseRepository _repository;

    public AddExpenseCommandHandler(IExpenseRepository repository)
    {
        _repository = repository;
    }

    protected override async Task<Expense> HandleValidatedCommandAsync(AddExpenseCommand command, CancellationToken cancellationToken) 
        => await _repository.AddAsync(new Expense(command.Description, command.Value, command.ExpenseDate, command.ExpenseCategoryId), x=> x.ExpenseCategory, cancellationToken);

    protected override void SetupRules()
    {
        RuleFor(command => command.Description)
            .NotEmpty()
            .MaximumLength(DatabaseFieldsLengthConstants.EXPENSE_DESCRIPTION_MAX_LENGTH);

        RuleFor(command => command.Value)
            .GreaterThan(0);

        RuleFor(command => command.ExpenseCategoryId).NotNull().NotEmpty();
    }
}
