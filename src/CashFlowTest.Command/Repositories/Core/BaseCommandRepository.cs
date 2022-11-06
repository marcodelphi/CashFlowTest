using CashFlowTest.Command.Abstractions.Repositories.Core;
using CashFlowTest.Crosscutting.Exceptions;
using CashFlowTest.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace CashFlowTest.Command.Repositories.Core;

public abstract class BaseCommandRepository<TEntity> : IBaseCommandRepository<TEntity> where TEntity : BaseEntity, IAggregateRoot<TEntity>
{
    protected readonly DbContext _context;

    protected DbSet<TEntity> _dbSet;

    public BaseCommandRepository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        var entry = _dbSet.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entry.Entity;
    }

    public async Task<TEntity> AddAsync<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> loadExpression, CancellationToken cancellationToken) where TProperty : class
    {
        var entry = _dbSet.Add(entity);

        ReferenceEntry<TEntity, TProperty> referenceEntry = _context.Entry(entry.Entity).Reference(loadExpression);

        await referenceEntry.LoadAsync(cancellationToken);

        if (referenceEntry.CurrentValue is null)
            throw new ReferenceEntityNotFoundException();

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
            throw new NotFoundException();

        return await actionIfExists(entity);
    }
}
