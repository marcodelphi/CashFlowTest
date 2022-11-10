using CashFlowTest.Command.Abstractions.Repositories;
using CashFlowTest.Command.Repositories.Core;
using CashFlowTest.Domain.Data.CommandContext;
using CashFlowTest.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlowTest.Command.Repositories;

public sealed class IncomeRepository : BaseCommandRepository<Income>, IIncomeRepository
{
    public IncomeRepository(CashFlowTestDataContext context) : base(context)
    {
    }

    public async Task<Income> GetAsync(Guid id, CancellationToken cancellationToken)
        => await _dbSet.FirstOrDefaultAsync(income => id.Equals(income.Id), cancellationToken);

    public async Task<Income> UpdateAsync(Guid id, string description, string note, decimal value, DateTime incomeDate, CancellationToken cancellationToken)
    {
        return await FindForUpdateAsync(id, cancellationToken, async (income) =>
        {
            income.Description = description;
            income.Note = note;
            income.Value = value;
            income.SetIncomeDate(incomeDate);

           _dbSet.Update(income);

            await _context.SaveChangesAsync(cancellationToken);

            return income;
        });
    }
}
