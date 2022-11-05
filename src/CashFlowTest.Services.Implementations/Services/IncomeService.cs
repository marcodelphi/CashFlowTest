using CashFlowTest.Command.Abstractions.Commands.IncomeCommands;
using CashFlowTest.Crosscutting.DTOs;
using CashFlowTest.Domain.Model.AdaptersContracts;
using CashFlowTest.Domain.Model.Entities;
using CashFlowTest.Services.Abstractions.Services;
using MediatR;

namespace CashFlowTest.Services.Implementations.Services;

public class IncomeService : BaseCrudService<Income, IncomeDto, AddIncomeCommand, UpdateIncomeCommand, DeleteIncomeCommand>, IIncomeService
{
    private readonly IIncomeAdapter _adapter;

    public IncomeService(IMediator mediator, IIncomeAdapter adapter) : base(mediator)
    {
        _adapter = adapter;
    }

    public Task<IncomeDto[]> GetAllIncomesAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    protected override IncomeDto ToDto(Income income) => _adapter.ToDto(income);
}
