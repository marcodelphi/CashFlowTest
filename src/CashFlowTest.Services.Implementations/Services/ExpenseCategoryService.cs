using CashFlowTest.Command.Abstractions.Commands.ExpenseCategoryCommands;
using CashFlowTest.Crosscutting.DTOs;
using CashFlowTest.Domain.Model.AdaptersContracts;
using CashFlowTest.Domain.Model.Entities;
using CashFlowTest.Query.Abstractions.Queries.ExpenseCategories;
using CashFlowTest.Services.Abstractions.Services;
using MediatR;

namespace CashFlowTest.Services.Implementations.Services;

public class ExpenseCategoryService : IExpenseCategoryService
{
    private readonly IMediator _mediator;
    private readonly IExpenseCategoryAdapter _adapter;

    public ExpenseCategoryService(IMediator mediator, IExpenseCategoryAdapter adapter)
    {
        _mediator = mediator;
        _adapter = adapter;
    }

    private ExpenseCategoryDto ToDto(ExpenseCategory expenseCategory) => _adapter.ToDto(expenseCategory);

    public async Task<ExpenseCategoryDto> AddExpenseCategoryAsync(AddExpenseCategoryCommand command, CancellationToken cancellationToken)
    {
        ExpenseCategory expenseCategory = await _mediator.Send(command, cancellationToken);

        return ToDto(expenseCategory);
    }

    public async Task DeleteExpenseCategoryAsync(DeleteExpenseCategoryCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
    }

    public async Task<ExpenseCategoryDto> UpdateExpenseCategoryAsync(UpdateExpenseCategoryCommand command, CancellationToken cancellationToken)
    {
        ExpenseCategory expenseCategory = await _mediator.Send(command, cancellationToken);

        return ToDto(expenseCategory);
    }

    public async Task<ExpenseCategoryDto[]> GetAllExpenseCategoriesAsync(CancellationToken cancellationToken)
    {
        ExpenseCategory[] expenseCategories = await _mediator.Send(new GetExpenseCategoriesQuery(), cancellationToken);

        return expenseCategories.Select(expenseCategory => ToDto(expenseCategory)).ToArray();
    }
}
