using CashFlowTest.Command.Abstractions.Commands.ExpenseCommands;
using CashFlowTest.Command.Abstractions.Repositories;
using CashFlowTest.Command.Repositories.Core;
using CashFlowTest.Crosscutting.Exceptions;
using CashFlowTest.Domain.Data.CommandContext;
using CashFlowTest.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CashFlowTest.Command.Repositories;

public sealed class ExpenseRepository : BaseCommandRepository<Expense>, IExpenseRepository
{
    public ExpenseRepository(CashFlowTestDataContext context) : base(context)
    {
    }

    public async Task<Expense> GetAsync(Guid id, CancellationToken cancellationToken) 
        => await _dbSet.FirstOrDefaultAsync(expense => id.Equals(expense.Id), cancellationToken);

    public async Task<Expense> UpdateAsync(UpdateExpenseCommand command, CancellationToken cancellationToken)
    {

        return await FindForUpdateAsync(command.Id, cancellationToken, async (expense) =>
        {
            expense.Description = command.Description;
            expense.ExpenseDate = command.ExpenseDate;
            expense.ExpenseCategoryId = command.ExpenseCategoryId;
            expense.Value = command.Value;

            ReferenceEntry<Expense, ExpenseCategory> expenseCategoryEntry = _context.Entry(expense).Reference(x => x.ExpenseCategory);

            await expenseCategoryEntry.LoadAsync(cancellationToken);

            if (expenseCategoryEntry.CurrentValue is null)
                throw new ReferenceEntityNotFoundException();

            _dbSet.Update(expense);

            await _context.SaveChangesAsync(cancellationToken);

            return expense;
        });
    }
}
