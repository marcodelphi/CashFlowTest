using CashFlowTest.Command.AbstractHandlers;
using CashFlowTest.Command.Abstractions.Commands.ExpenseCategoryCommands;
using CashFlowTest.Command.Abstractions.Repositories;
using CashFlowTest.Crosscutting.Constants;
using CashFlowTest.Domain.Model.Entities;
using FluentValidation;
using MediatR;

namespace CashFlowTest.Command.Handlers.ExpenseCategoryHandlers;

internal sealed class UpdateExpenseCategoryCommandHandler : EntityValidationCommandHandler<UpdateExpenseCategoryCommand, ExpenseCategory>
{
    private readonly IExpenseCategoryRepository _repository;

    public UpdateExpenseCategoryCommandHandler(IMediator mediator, IExpenseCategoryRepository respository) : base(mediator) => _repository = respository;

    protected override async Task<ExpenseCategory> HandleValidatedCommandAsync(UpdateExpenseCategoryCommand command, CancellationToken cancellationToken)
        => await _repository.UpdateAsync(command.Id, command.Description, cancellationToken);

    protected override void SetupRules()
        => RuleFor(command => command.Description)
            .NotEmpty()
            .MaximumLength(DatabaseFieldsLengthConstants.EXPENSE_CATEGORY_DESCRIPTION_MAX_LENGTH);
}
