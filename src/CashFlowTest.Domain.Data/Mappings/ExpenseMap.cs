using CashFlowTest.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashFlowTest.Domain.Data.Mappings;

internal class ExpenseMap : IEntityTypeConfiguration<Expense>
{
    public void Configure(EntityTypeBuilder<Expense> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.ExpenseCategory);
    }
}
