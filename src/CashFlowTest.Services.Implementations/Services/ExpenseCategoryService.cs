using CashFlowTest.Command.Abstractions.Commands.ExpenseCategoryCommands;
using CashFlowTest.Crosscutting.DTOs;
using CashFlowTest.Domain.Model.AdaptersContracts;
using CashFlowTest.Domain.Model.Entities;
using CashFlowTest.Query.Abstractions.Queries.ExpenseCategories;
using CashFlowTest.Services.Abstractions.Services;
using CashFlowTest.Services.Implementations.Services.Core;
using MediatR;

namespace CashFlowTest.Services.Implementations.Services;

public class ExpenseCategoryService : BaseCrudService<ExpenseCategory, ExpenseCategoryDto, AddExpenseCategoryCommand, UpdateExpenseCategoryCommand, DeleteExpenseCategoryCommand>, IExpenseCategoryService
{
    private readonly IExpenseCategoryAdapter _adapter;

    public ExpenseCategoryService(IMediator mediator, IExpenseCategoryAdapter adapter) : base(mediator)
    {
        _adapter = adapter;
    }

    protected override ExpenseCategoryDto ToDto(ExpenseCategory expenseCategory) => _adapter.ToDto(expenseCategory);

    public async Task<ExpenseCategoryDto[]> GetAllExpenseCategoriesAsync(CancellationToken cancellationToken)
    {
        ExpenseCategory[] expenseCategories = await _mediator.Send(new GetExpenseCategoriesQuery(), cancellationToken);

        return expenseCategories.Select(expenseCategory => ToDto(expenseCategory)).ToArray();
    }
}
