namespace CashFlowTest.Command.Abstractions.Repositories;

public interface ICommandRepository<TEntity>
{
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}
