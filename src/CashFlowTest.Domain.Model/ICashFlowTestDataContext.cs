using CashFlowTest.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CashFlowTest.Domain.Model;

public interface ICashFlowTestDataContext
{
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
    public DbSet<Income> Incomes { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    DatabaseFacade Database { get; }
}
