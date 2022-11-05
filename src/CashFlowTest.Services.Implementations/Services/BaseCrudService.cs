using CashFlowTest.Command.Abstractions;
using CashFlowTest.Domain.Model;
using CashFlowTest.Services.Abstractions.Services;
using MediatR;

namespace CashFlowTest.Services.Implementations.Services;

public abstract class BaseCrudService<TEntity, TResult, TAddCommand, TUpdateCommand, TDeleteCommand> : IBaseCrudService<TEntity, TResult, TAddCommand, TUpdateCommand, TDeleteCommand> where TEntity : BaseEntity
    where TResult : class
    where TAddCommand : Command<TEntity>
    where TUpdateCommand : Command<TEntity>
    where TDeleteCommand : CommandWithId
{
    protected readonly IMediator _mediator;

    public BaseCrudService(IMediator mediator)
    {
        _mediator = mediator;
    }

    protected abstract TResult ToDto(TEntity entity);

    public async Task<TResult> AddAsync(TAddCommand command, CancellationToken cancellationToken)
    {
        TEntity entity = await _mediator.Send(command, cancellationToken);

        return ToDto(entity);
    }

    public async Task DeleteAsync(TDeleteCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
    }

    public async Task<TResult> UpdateAsync(TUpdateCommand command, CancellationToken cancellationToken)
    {
        TEntity entity = await _mediator.Send(command, cancellationToken);

        return ToDto(entity);
    }
}
