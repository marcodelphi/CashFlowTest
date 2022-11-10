using CashFlowTest.Command.AbstractHandlers;
using CashFlowTest.Command.Abstractions.Commands.ExpenseCommands;
using CashFlowTest.Command.Abstractions.Repositories;
using CashFlowTest.Crosscutting.Constants;
using CashFlowTest.Domain.Model.Entities;
using CashFlowTest.Notifications.Notifications;
using FluentValidation;
using MediatR;

namespace CashFlowTest.Command.Handlers.ExpenseHandlers;

internal sealed class AddExpenseCommandHandler : EntityValidationCommandHandler<AddExpenseCommand, Expense>
{
    private readonly IExpenseRepository _repository;

    public AddExpenseCommandHandler(IMediator mediator, IExpenseRepository repository) : base(mediator) => _repository = repository;

    protected override async Task<Expense> HandleValidatedCommandAsync(AddExpenseCommand command, CancellationToken cancellationToken)
    {
        Expense expense = await _repository.AddAsync(new Expense(command.Description, command.Value, command.ExpenseDate, command.ExpenseCategoryId), x => x.ExpenseCategory, cancellationToken);

        await _mediator.Publish(new ExpenseAddNotification(expense.Id, expense.Description, expense.Value, expense.CreatedDate, expense.ExpenseDate, expense.ExpenseCategory.Description), cancellationToken);

        return expense;
    }

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
