using CashFlowTest.Domain.Model.Entities;
using CashFlowTest.Query.AbstractHandlers;
using CashFlowTest.Query.Abstractions.Queries.IncomeQueries;
using CashFlowTest.Query.Abstractions.Repositories;

namespace CashFlowTest.Query.Handlers.IncomeHandlers;

internal sealed class GetIncomesQueryHandler : SimpleQueryHandler<GetIncomesQuery, Income[]>
{
    private readonly IIncomeQueryRepository _repository;

    public GetIncomesQueryHandler(IIncomeQueryRepository repository)
    {
        _repository = repository;
    }

    protected override async Task<Income[]> HandleQueryAsync(GetIncomesQuery query, CancellationToken cancellationToken)
        => await _repository.GetAllAsync(cancellationToken);
}
