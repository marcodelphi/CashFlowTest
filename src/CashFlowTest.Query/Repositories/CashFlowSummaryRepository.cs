using CashFlowTest.Domain.Data.CommandContext;
using CashFlowTest.Domain.Model.Entities.ReadContext;
using CashFlowTest.Query.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CashFlowTest.Query.Repositories;

public class CashFlowSummaryRepository : BaseQueryRepository<SummaryEvent>, ICashFlowSummaryRepository
{
    public CashFlowSummaryRepository(CashFlowTestQueryContext context) : base(context)
    {
    }

    public DbContext DbContext => _context;
}
