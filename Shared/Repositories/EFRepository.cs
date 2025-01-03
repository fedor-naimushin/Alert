using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using Shared.Repositories.Infrastructure;

namespace Shared.Repositories;

public abstract class EFRepository<TEntity, TDbContext>(TDbContext context) : RepositoryBase<TEntity>(context)
    where TEntity : class, IAggregateRoot
    where TDbContext : DbContext, IUnitOfWork
{
    protected virtual IQueryable<TEntity> Items => IsReadonly ? _items.AsNoTracking() : _items;
    
    private readonly DbContext _context = context;
    private DbSet<TEntity> _items => _context.Set<TEntity>();


    public override async Task<TEntity> AddAsync(TEntity aggregateRoot, CancellationToken cancellationToken)
    {
        return (await _items.AddAsync(aggregateRoot, cancellationToken)).Entity;
    }

    public override async Task<int> AddRangeAsync(IReadOnlyList<TEntity> aggregateRoots, CancellationToken cancellationToken)
    {
        await _items.AddRangeAsync(aggregateRoots, cancellationToken);
        return aggregateRoots.Count;
    }

    public override Task RemoveAsync(TEntity aggregateRoot, CancellationToken cancellationToken)
    {
        return Task.FromResult(_items.Remove(aggregateRoot));
    }
    
    public override Task RemoveRangeAsync(IReadOnlyList<TEntity> aggregateRoots, CancellationToken cancellationToken)
    {
        _items.RemoveRange(aggregateRoots);
        return Task.CompletedTask;
    }
    
    public override ValueTask<TEntity?> GetById(long id, CancellationToken cancellationToken)
    {
        return _items.FindAsync(new object?[] { id }, cancellationToken: cancellationToken);
    }

    public override ValueTask<TEntity?> GetByIds(object[] keyValues, CancellationToken cancellationToken)
    {
        return _items.FindAsync(keyValues, cancellationToken);
    }

    public override async Task<IReadOnlyList<TEntity>> ListAsync(CancellationToken cancellationToken)
    {
        return await Items.ToListAsync(cancellationToken);
    }

    public override async Task<IReadOnlyList<TEntity>> ListAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        return await Items.Where(predicate).ToListAsync(cancellationToken);
    }

    public override Task<TEntity> SingleAsync(CancellationToken cancellationToken)
    {
        return Items.SingleAsync(cancellationToken);
    }

    public override Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        return Items.SingleAsync(predicate, cancellationToken);
    }

    public override Task<TEntity?> SingleOrDefault(CancellationToken cancellationToken)
    {
        return Items.SingleOrDefaultAsync(cancellationToken);
    }

    public override Task<TEntity?> SingleOrDefault(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        return Items.Where(predicate).SingleOrDefaultAsync(cancellationToken);
    }

    public override Task<TEntity> FirstAsync(CancellationToken cancellationToken)
    {
        return Items.FirstAsync(cancellationToken);
    }

    public override Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        return Items.Where(predicate).FirstAsync(cancellationToken);
    }

    public override Task<TEntity?> FirstOrDefaultAsync(CancellationToken cancellationToken)
    {
        return Items.FirstOrDefaultAsync(cancellationToken);
    }

    public override Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        return Items.Where(predicate).FirstOrDefaultAsync(cancellationToken);
    }

    public override Task<int> CountAsync(CancellationToken cancellationToken)
    {
        return Items.CountAsync(cancellationToken);
    }

    public override Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        return Items.CountAsync(predicate, cancellationToken);
    }

    public override async Task<IReadOnlyList<TResult>> QueryAsync<TResult>(Func<IQueryable<TEntity>, IQueryable<TResult>> predicate, CancellationToken cancellationToken)
    {
        return await predicate(Items).ToListAsync(cancellationToken);
    }
}