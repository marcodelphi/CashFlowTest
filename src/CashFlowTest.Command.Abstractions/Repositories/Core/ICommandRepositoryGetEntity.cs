using CashFlowTest.Domain.Model;

namespace CashFlowTest.Command.Abstractions.Repositories.Core;

public interface ICommandRepositoryGetEntity<TEntity> where TEntity : BaseEntity, IAggregateRoot<TEntity>
{
    Task<TEntity> GetAsync(Guid id, CancellationToken cancellationToken);
}
