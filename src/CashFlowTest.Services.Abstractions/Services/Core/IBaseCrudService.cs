namespace CashFlowTest.Services.Abstractions.Services.Core;

public interface IBaseCrudService<TEntity, TResult, TAddCommand, TUpdateCommand, TDeleteCommand>
{
    Task<TResult> AddAsync(TAddCommand command, CancellationToken cancellationToken);
    Task DeleteAsync(TDeleteCommand command, CancellationToken cancellationToken);
    Task<TResult> UpdateAsync(TUpdateCommand command, CancellationToken cancellationToken);
}