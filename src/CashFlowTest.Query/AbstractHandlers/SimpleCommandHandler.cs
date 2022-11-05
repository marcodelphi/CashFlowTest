using MediatR;

namespace CashFlowTest.Query.AbstractHandlers;

internal abstract class SimpleQueryHandler<TQuery, TResult> : IRequestHandler<TQuery, TResult> where TQuery : IRequest<TResult>
{
    public async Task<TResult> Handle(TQuery query, CancellationToken cancellationToken) => await HandleQueryAsync(query, cancellationToken);

    protected abstract Task<TResult> HandleQueryAsync(TQuery query, CancellationToken cancellationToken);
}

internal abstract class SimpleQueryHandler<TQuery> : SimpleQueryHandler<TQuery, Unit> where TQuery : IRequest
{
}
