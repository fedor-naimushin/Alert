using System.Linq.Expressions;
using NotificationGateway.Core;
using NotificationGateway.DataStore.Repositories.Infrastructure;

namespace NotificationGateway.DataStore.Repositories;

public abstract class ReadonlyRepositoryBase<TAggregateRoot> : IReadonlyRepository<TAggregateRoot> where TAggregateRoot : class, IAggregateRoot
{
    public abstract Task<TAggregateRoot> GetById(long id, CancellationToken cancellationToken);
    public abstract Task<TAggregateRoot> GetById(object[] keyValues, CancellationToken cancellationToken);
    
    public abstract Task<IReadOnlyList<TAggregateRoot>> ListAsync(CancellationToken cancellationToken);
    public abstract Task<IReadOnlyList<TAggregateRoot>> ListAsync(Expression<Func<TAggregateRoot, bool>> predicate, CancellationToken cancellationToken);
    
    public abstract Task<TAggregateRoot> SingleAsync(CancellationToken cancellationToken);
    public abstract Task<TAggregateRoot> SingleAsync(Expression<Func<TAggregateRoot, bool>> predicate, CancellationToken cancellationToken);
    
    public abstract Task<TAggregateRoot> SingleOrDefault(CancellationToken cancellationToken);
    public abstract Task<TAggregateRoot> SingleOrDefault(Expression<Func<TAggregateRoot, bool>> predicate, CancellationToken cancellationToken);
    
    public abstract Task<TAggregateRoot> FirstAsync(CancellationToken cancellationToken);
    public abstract Task<TAggregateRoot> FirstAsync(Expression<Func<TAggregateRoot, bool>> predicate, CancellationToken cancellationToken);
    
    public abstract Task<TAggregateRoot> FirstOrDefaultAsync(CancellationToken cancellationToken);
    public abstract Task<TAggregateRoot> FirstOrDefaultAsync(Expression<Func<TAggregateRoot, bool>> predicate, CancellationToken cancellationToken);
    
    public abstract Task<int> CountAsync(CancellationToken cancellationToken);
    public abstract Task<int> CountAsync(Expression<Func<TAggregateRoot, bool>> predicate, CancellationToken cancellationToken);
    
    public abstract Task<long> LongCountAsync(CancellationToken cancellationToken);
    public abstract Task<long> LongCountAsync(Expression<Func<TAggregateRoot, bool>> predicate, CancellationToken cancellationToken);
    
    public abstract Task<IReadOnlyList<TResult>> QueryAsync<TResult>(Expression<Func<IQueryable<TAggregateRoot>, IQueryable<TResult>>> predicate, CancellationToken cancellationToken);
}