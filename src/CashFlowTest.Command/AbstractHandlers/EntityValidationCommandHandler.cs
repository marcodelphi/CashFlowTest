using FluentValidation;
using MediatR;

namespace CashFlowTest.Command.AbstractHandlers;

internal abstract class EntityValidationCommandHandler<TCommand, TResult> : AbstractValidator<TCommand>, IRequestHandler<TCommand, TResult> where TCommand : IRequest<TResult>
{
    protected readonly IMediator _mediator;

    public EntityValidationCommandHandler(IMediator mediator) => _mediator = mediator;

    public async Task<TResult> Handle(TCommand command, CancellationToken cancellationToken)
    {
        SetupRules();

        await this.ValidateAndThrowAsync(command, cancellationToken);

        return await HandleValidatedCommandAsync(command, cancellationToken);
    }

    protected abstract void SetupRules();

    protected abstract Task<TResult> HandleValidatedCommandAsync(TCommand command, CancellationToken cancellationToken);
}