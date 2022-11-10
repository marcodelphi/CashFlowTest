using CashFlowTest.Crosscutting.DTOs;

namespace CashFlowTest.Services.Abstractions.Services;

public interface ICashFlowService
{
    Task AddExpenseAsync(SummaryInput summaryInput, CancellationToken cancellationToken);
    Task AddIncomeAsync(SummaryInput summaryInput, CancellationToken cancellationToken);
    Task DeleteExpenseAsync(SummaryInput summaryInput, CancellationToken cancellationToken);
    Task DeleteIncomeAsync(SummaryInput summaryInput, CancellationToken cancellationToken);
    Task<SummaryDto[]> GetDailyReportAsync(CancellationToken cancellationToken);
}