using CashFlowTest.Domain.Model.Entities;
using CashFlowTest.Query.AbstractHandlers;
using CashFlowTest.Query.Abstractions.Queries.ExpenseCategories;
using CashFlowTest.Query.Repositories;

namespace CashFlowTest.Query.Handlers.ExpenseCategories;

internal sealed class GetExpenseCategoriesQueryHandler : SimpleQueryHandler<GetExpenseCategoriesQuery, ExpenseCategory[]>
{
    private readonly IExpenseCategoryQueryRespository _repository;

    public GetExpenseCategoriesQueryHandler(IExpenseCategoryQueryRespository repository)
    {
        _repository = repository;
    }

    protected override async Task<ExpenseCategory[]> HandleQueryAsync(GetExpenseCategoriesQuery query, CancellationToken cancellationToken) 
        => await _repository.GetAllAsync(cancellationToken);
}
