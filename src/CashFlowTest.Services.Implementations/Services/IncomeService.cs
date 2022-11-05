using CashFlowTest.Command.Abstractions.Commands.IncomeCommands;
using CashFlowTest.Crosscutting.DTOs;
using CashFlowTest.Domain.Model.AdaptersContracts;
using CashFlowTest.Domain.Model.Entities;
using CashFlowTest.Query.Abstractions.Queries.IncomeQueries;
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

    protected override IncomeDto ToDto(Income income) => _adapter.ToDto(income);

    public async Task<IncomeDto[]> GetAllIncomesAsync(CancellationToken cancellationToken)
    {
        Income[] incomes = await _mediator.Send(new GetIncomesQuery(), cancellationToken);

        return incomes.Select(income => ToDto(income)).ToArray();
    }
}
