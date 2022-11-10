using CashFlowTest.Domain.Model.Entities.ReadContext;
using Microsoft.EntityFrameworkCore;

namespace CashFlowTest.Query.Abstractions.Repositories;

public interface ICashFlowSummaryRepository: IBaseQueryRepository<SummaryEvent>
{
    DbContext DbContext { get; }
}