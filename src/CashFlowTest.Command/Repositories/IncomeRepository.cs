using CashFlowTest.Command.Abstractions.Repositories;
using CashFlowTest.Domain.Data;
using CashFlowTest.Domain.Model.Entities;

namespace CashFlowTest.Command.Repositories;

public sealed class IncomeRepository : BaseCommandRepository<Income>, IIncomeRepository
{
    public IncomeRepository(CashFlowTestDataContext context) : base(context)
    {
    }

    public async Task<Income> UpdateAsync(Guid id, string description, string note, decimal value, DateTime incomeDate, CancellationToken cancellationToken)
    {
        return await FindForUpdateAsync(id, cancellationToken, async (income) =>
        {
            income.Description = description;
            income.Note = note;
            income.Value = value;
            income.IncomeDate = incomeDate;

           _dbSet.Update(income);

            await _context.SaveChangesAsync(cancellationToken);

            return income;
        });
    }
}
