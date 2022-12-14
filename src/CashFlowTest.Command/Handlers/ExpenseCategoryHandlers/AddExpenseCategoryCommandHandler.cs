using CashFlowTest.Command.AbstractHandlers;
using CashFlowTest.Command.Abstractions.Commands.ExpenseCategoryCommands;
using CashFlowTest.Command.Abstractions.Repositories;
using CashFlowTest.Crosscutting.Constants;
using CashFlowTest.Domain.Model.Entities;
using FluentValidation;
using MediatR;

namespace CashFlowTest.Command.Handlers.ExpenseCategoryHandlers;

internal sealed class AddExpenseCategoryCommandHandler : EntityValidationCommandHandler<AddExpenseCategoryCommand, ExpenseCategory>
{
    private readonly IExpenseCategoryRepository _repository;

    public AddExpenseCategoryCommandHandler(IMediator mediator, IExpenseCategoryRepository repository) : base(mediator) => _repository = repository;

    protected override async Task<ExpenseCategory> HandleValidatedCommandAsync(AddExpenseCategoryCommand command, CancellationToken cancellationToken)
        => await _repository.AddAsync(new ExpenseCategory(command.Description), cancellationToken);

    protected override void SetupRules()
        => RuleFor(command => command.Description)
            .NotEmpty()
            .MaximumLength(DatabaseFieldsLengthConstants.EXPENSE_CATEGORY_DESCRIPTION_MAX_LENGTH);
}
