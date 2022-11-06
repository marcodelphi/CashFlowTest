using CashFlowTest.Crosscutting.DTOs;
using CashFlowTest.Domain.Model.AdaptersContracts;
using CashFlowTest.Domain.Model.Entities;

namespace CashFlowTest.Domain.Model.Adapters;

public sealed class ExpenseAdapter : IExpenseAdapter
{
    public ExpenseDto ToDto(Expense source) => new ExpenseDto
    {
        CreatedDate = source.CreatedDate,
        ExpenseCategoryId = source.ExpenseCategoryId,
        Description = source.Description,
        ExpenseCategory = source.ExpenseCategory.Description,
        ExpenseDate = source.ExpenseDate,
        Id = source.Id,
        Value = source.Value
    };

    public Expense ToModel(ExpenseDto target) => new Expense(target.Description, target.Value, target.ExpenseDate, target.ExpenseCategoryId);
}
