using CashFlowTest.Domain.Model.Entities;
using CashFlowTest.Query.AbstractHandlers;
using CashFlowTest.Query.Abstractions.Queries.ExpenseCategories;
using CashFlowTest.Query.Abstractions.Repositories;

namespace CashFlowTest.Query.Handlers.ExpenseCategoryHandlers;

internal sealed class GetExpenseCategoriesQueryHandler : SimpleQueryHandler<GetExpenseCategoriesQuery, ExpenseCategory[]>
{
    private readonly IExpenseCategoryQueryRepository _repository;

    public GetExpenseCategoriesQueryHandler(IExpenseCategoryQueryRepository repository)
    {
        _repository = repository;
    }

    protected override async Task<ExpenseCategory[]> HandleQueryAsync(GetExpenseCategoriesQuery query, CancellationToken cancellationToken)
        => await _repository.GetAllAsync(cancellationToken);
}
