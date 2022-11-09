using CashFlowTest.Command.Abstractions.Repositories;
using CashFlowTest.Command.Repositories.Core;
using CashFlowTest.Domain.Data.CommandContext;
using CashFlowTest.Domain.Model.Entities;

namespace CashFlowTest.Command.Repositories;

public sealed class ExpenseCategoryRepository : BaseCommandRepository<ExpenseCategory>, IExpenseCategoryRepository
{
    public ExpenseCategoryRepository(CashFlowTestDataContext context) : base(context)
    {
    }

    public async Task<ExpenseCategory> UpdateAsync(Guid id, string newDescription, CancellationToken cancellationToken)
    {
        return await FindForUpdateAsync(id, cancellationToken, async (expenseCategory) =>
        {
            expenseCategory.Description = newDescription;

           _dbSet.Update(expenseCategory);

            await _context.SaveChangesAsync(cancellationToken);

            return expenseCategory;
        });
    }
}
