using CashFlowTest.Crosscutting.DTOs;
using CashFlowTest.Domain.Model.Entities.ReadContext;
using CashFlowTest.Query.Abstractions.Repositories;
using CashFlowTest.Services.Abstractions.Services;
using Microsoft.EntityFrameworkCore;

namespace CashFlowTest.Services.Implementations.Services;

public sealed class CashFlowService : ICashFlowService
{
    private readonly ICashFlowSummaryRepository _repository;

    private DbSet<SummaryEvent> _dbSet => _repository.DbSet;

    private DbContext _context => _repository.DbContext;

    public CashFlowService(ICashFlowSummaryRepository repository) => _repository = repository;

    private async Task<SummaryEvent> FindSummaryEventAsync(SummaryInput summaryInput, CancellationToken cancellationToken) 
        => await _dbSet.FirstOrDefaultAsync(x => x.Date == summaryInput.EventDate, cancellationToken);

    private static SummaryEvent CreateNewSummaryEvent(SummaryInput summaryInput) => new SummaryEvent(summaryInput.EventDate);

    private async Task AddAndSaveSummaryEventAsync(SummaryEvent summaryEvent, CancellationToken cancellationToken)
    {
        _dbSet.Add(summaryEvent);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task AddExpenseAsync(SummaryInput summaryInput, CancellationToken cancellationToken) 
        => await AddSummaryEventAsync(summaryInput, (summaryEvent) => summaryEvent.AddExpense(summaryInput.Value), cancellationToken);

    public async Task AddIncomeAsync(SummaryInput summaryInput, CancellationToken cancellationToken)
        => await AddSummaryEventAsync(summaryInput, (summaryEvent) => summaryEvent.AddIncome(summaryInput.Value), cancellationToken);

    public async Task DeleteExpenseAsync(SummaryInput summaryInput, CancellationToken cancellationToken) 
        => await DeleteSummaryEventAsync(summaryInput, (summaryEvent) => summaryEvent.RemoveExpense(summaryInput.Value), cancellationToken);

    public async Task DeleteIncomeAsync(SummaryInput summaryInput, CancellationToken cancellationToken) 
        => await DeleteSummaryEventAsync(summaryInput, (summaryEvent) => summaryEvent.RemoveIncome(summaryInput.Value), cancellationToken);

    public async Task<SummaryDto[]> GetDailyReportAsync(CancellationToken cancellationToken)
    {
        SummaryEvent[] allData = await _repository.GetAllAsync(cancellationToken);

        return allData.Select(x => new SummaryDto
        {
            Date = x.Date,
            TotalIncome = x.TotalIncome,
            TotalExpense = x.TotalExpense,
            Balance = x.Balance
        }).ToArray();
    }

    public async Task AddSummaryEventAsync(SummaryInput summaryInput, Func<SummaryEvent, SummaryEvent> summaryAction, CancellationToken cancellationToken)
    {
        SummaryEvent summaryEvent = await FindSummaryEventAsync(summaryInput, cancellationToken);

        if (summaryEvent is null)
        {
            summaryEvent = CreateNewSummaryEvent(summaryInput);

            summaryAction(summaryEvent);

            await AddAndSaveSummaryEventAsync(summaryEvent, cancellationToken);
            return;
        }

        summaryAction(summaryEvent);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteSummaryEventAsync(SummaryInput summaryInput, Func<SummaryEvent, SummaryEvent> summaryAction, CancellationToken cancellationToken)
    {
        SummaryEvent summaryEvent = await FindSummaryEventAsync(summaryInput, cancellationToken);

        if (summaryEvent is null)
            return;

        summaryAction(summaryEvent);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
