using CashFlowTest.Command.Abstractions.Repositories;
using CashFlowTest.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace CashFlowTest.Command.Repositories;

public abstract class BaseCommandRepository<TEntity> : IBaseCommandRepository<TEntity> where TEntity : BaseEntity, IAggregateRoot<TEntity>
{
    protected readonly DbContext _context;

    protected DbSet<TEntity> _dbSet;

    public BaseCommandRepository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        var entry = _dbSet.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entry.Entity;
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await FindAsync(id, cancellationToken, async (entity) =>
        {
            _dbSet.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);
        });
    }

    private async Task FindAsync(Guid id, CancellationToken cancellationToken, Func<TEntity, Task> actionIfExists)
    {
        TEntity entity = await _dbSet.FirstOrDefaultAsync(entity => id.Equals(entity.Id), cancellationToken);

        if (entity is not null)
            await actionIfExists(entity);
    }

    public async Task<TEntity> FindForUpdateAsync(Guid id, CancellationToken cancellationToken, Func<TEntity, Task<TEntity>> actionIfExists)
    {
        TEntity entity = await _dbSet.FirstOrDefaultAsync(extity => id.Equals(extity.Id), cancellationToken);

        if (entity is null)
            return null;

        return await actionIfExists(entity);
    }
}
