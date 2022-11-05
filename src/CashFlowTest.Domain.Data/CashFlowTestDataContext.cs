using CashFlowTest.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlowTest.Domain.Data;

public sealed class CashFlowTestDataContext : DbContext
{
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
    public DbSet<Income> Incomes { get; set; }

    public CashFlowTestDataContext(DbContextOptions<CashFlowTestDataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) => base.OnModelCreating(modelBuilder);
}