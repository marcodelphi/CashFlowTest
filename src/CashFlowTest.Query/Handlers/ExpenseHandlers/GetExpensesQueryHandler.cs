using CashFlowTest.Domain.Model.Entities;
using CashFlowTest.Query.AbstractHandlers;
using CashFlowTest.Query.Abstractions.Queries.ExpenseQueries;
using CashFlowTest.Query.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CashFlowTest.Query.Handlers.IncomeHandlers;

internal sealed class GetExpensesQueryHandler : SimpleQueryHandler<GetExpensesQuery, Expense[]>
{
    private readonly IExpenseQueryRepository _repository;

    public GetExpensesQueryHandler(IExpenseQueryRepository repository)
    {
        _repository = repository;
    }

    protected override async Task<Expense[]> HandleQueryAsync(GetExpensesQuery query, CancellationToken cancellationToken)
        => await _repository.Queryable()
            .AsNoTracking()
            .Include(expense => expense.ExpenseCategory)
            .ToArrayAsync(cancellationToken);
}
