using CashFlowTest.Command.Abstractions.Repositories;
using CashFlowTest.Domain.Model;
using CashFlowTest.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlowTest.Command.Repositories;

public sealed class ExpenseCategoryRepository : IExpenseCategoryRepository
{
    private readonly ICashFlowTestDataContext _context;

    public ExpenseCategoryRepository(ICashFlowTestDataContext context)
    {
        _context = context;
    }

    public async Task<ExpenseCategory> AddAsync(ExpenseCategory entity, CancellationToken cancellationToken)
    {
        var entry = _context.ExpenseCategories.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entry.Entity;
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await FindAsync(id, cancellationToken, async (expenseCategory) =>
        {
            _context.ExpenseCategories.Remove(expenseCategory);

            await _context.SaveChangesAsync(cancellationToken);
        });
    }

    public async Task<ExpenseCategory> UpdateAsync(Guid id, string newDescription, CancellationToken cancellationToken)
    {
        return await FindAndUpdateAsync(id, cancellationToken, async (expenseCategory) =>
        {
            expenseCategory.Description = newDescription;

            _context.ExpenseCategories.Update(expenseCategory);

            await _context.SaveChangesAsync(cancellationToken);

            return expenseCategory;
        });
    }

    private async Task FindAsync(Guid id, CancellationToken cancellationToken, Func<ExpenseCategory, Task> actionIfExists)
    {
        ExpenseCategory expenseCategory = await _context.ExpenseCategories.FirstOrDefaultAsync(expenseCategory => id.Equals(expenseCategory.Id), cancellationToken);

        if (expenseCategory is not null)
            await actionIfExists(expenseCategory);
    }

    private async Task<ExpenseCategory> FindAndUpdateAsync(Guid id, CancellationToken cancellationToken, Func<ExpenseCategory, Task<ExpenseCategory>> actionIfExists)
    {
        ExpenseCategory expenseCategory = await _context.ExpenseCategories.FirstOrDefaultAsync(expenseCategory => id.Equals(expenseCategory.Id), cancellationToken);

        if (expenseCategory is null)
            return null;

        return await actionIfExists(expenseCategory);
    }
}
