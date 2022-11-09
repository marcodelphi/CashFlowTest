using CashFlowTest.Domain.Data.Mappings;
using CashFlowTest.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlowTest.Domain.Data.CommandContext;

public sealed class CashFlowTestDataContext : DbContext
{
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
    public DbSet<Income> Incomes { get; set; }

    public CashFlowTestDataContext(DbContextOptions<CashFlowTestDataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ExpenseMap());

        base.OnModelCreating(modelBuilder);
    }
}