using CashFlowTest.Crosscutting.DTOs;
using CashFlowTest.Domain.Model.AdaptersContracts;
using CashFlowTest.Domain.Model.Entities;

namespace CashFlowTest.Domain.Model.Adapters;

public sealed class ExpenseCategoryAdapter : IExpenseCategoryAdapter
{
    public ExpenseCategoryDto ToDto(ExpenseCategory source)
    {
        return new ExpenseCategoryDto(source.Id, source.Description);
    }

    public ExpenseCategory ToModel(ExpenseCategoryDto target)
    {
        return new ExpenseCategory(target.Description);
    }
}
