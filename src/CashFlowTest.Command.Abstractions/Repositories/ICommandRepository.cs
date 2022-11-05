using CashFlowTest.Domain.Model;

namespace CashFlowTest.Command.Abstractions.Repositories;

public interface ICommandRepository<TEntity> where TEntity: BaseEntity, IAggregateRoot<TEntity>
{
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}
