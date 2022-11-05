using CashFlowTest.Domain.Model;
using CashFlowTest.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlowTest.Query.Repositories;

internal class ExpenseCategoryQueryRespository : IExpenseCategoryQueryRespository
{
    private readonly ICashFlowTestDataContext _context;

    public ExpenseCategoryQueryRespository(ICashFlowTestDataContext context)
    {
        _context = context;
    }

    public async Task<ExpenseCategory> GetAsync(Guid id, CancellationToken cancellationToken)
        => await _context.ExpenseCategories.Where(expenseCategory => id.Equals(expenseCategory.Id)).FirstOrDefaultAsync(cancellationToken);

    public async Task<ExpenseCategory[]> GetAllAsync(CancellationToken cancellationToken) 
        => await _context.ExpenseCategories.ToArrayAsync(cancellationToken);

}
