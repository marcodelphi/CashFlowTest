using CashFlowTest.Domain.Model;

namespace CashFlowTest.Query.Repositories;

public interface IQueryRepository<TEntity> where TEntity : BaseEntity, IAggregateRoot<TEntity>
{
    Task<TEntity> GetAsync(Guid id, CancellationToken cancellationToken);
}
