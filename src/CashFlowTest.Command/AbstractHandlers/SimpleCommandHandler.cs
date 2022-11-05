using MediatR;

namespace CashFlowTest.Command.AbstractHandlers;

internal abstract class SimpleCommandHandler<TCommand, TResult> : IRequestHandler<TCommand, TResult> where TCommand : IRequest<TResult>
{
    public async Task<TResult> Handle(TCommand command, CancellationToken cancellationToken) => await HandleCommandAsync(command, cancellationToken);

    protected abstract Task<TResult> HandleCommandAsync(TCommand command, CancellationToken cancellationToken);
}

internal abstract class SimpleCommandHandler<TCommand> : SimpleCommandHandler<TCommand, Unit> where TCommand : IRequest
{
}
