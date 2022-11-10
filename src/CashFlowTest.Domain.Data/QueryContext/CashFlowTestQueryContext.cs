using CashFlowTest.Domain.Model.Entities.ReadContext;
using Microsoft.EntityFrameworkCore;

namespace CashFlowTest.Domain.Data.CommandContext;

public sealed class CashFlowTestQueryContext : DbContext
{
    public DbSet<SummaryEvent> CashFlowSummaries { get; set; }

    public CashFlowTestQueryContext(DbContextOptions<CashFlowTestQueryContext> options) : base(options)
    {
    }
}