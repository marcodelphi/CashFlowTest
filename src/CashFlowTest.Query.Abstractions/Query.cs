using MediatR;

namespace CashFlowTest.Query.Abstractions;

public abstract class Query : Query<Unit>, IRequest
{
}

public abstract class Query<TResult> : IRequest<TResult>
{
}

public abstract class QueryWithId : Query
{
    public Guid Id { get; }

    public QueryWithId(Guid id)
    {
        Id = id;
    }
}