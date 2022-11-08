using MediatR;

namespace CashFlowTest.Command.AbstractHandlers;

internal abstract class SimpleCommandHandler<TCommand, TResult> : IRequestHandler<TCommand, TResult> where TCommand : IRequest<TResult>
{
    public readonly IMediator _mediator;

    public SimpleCommandHandler(IMediator mediator) => _mediator = mediator;

    public async Task<TResult> Handle(TCommand command, CancellationToken cancellationToken) => await HandleCommandAsync(command, cancellationToken);

    protected abstract Task<TResult> HandleCommandAsync(TCommand command, CancellationToken cancellationToken);
}

internal abstract class SimpleCommandHandler<TCommand> : SimpleCommandHandler<TCommand, Unit> where TCommand : IRequest
{
    protected SimpleCommandHandler(IMediator mediator) : base(mediator)
    {
    }
}
