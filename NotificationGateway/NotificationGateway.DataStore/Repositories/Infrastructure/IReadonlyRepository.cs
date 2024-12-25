using System.Linq.Expressions;
using NotificationGateway.Core;

namespace NotificationGateway.DataStore.Repositories.Infrastructure;

public interface IReadonlyRepository<TAggregateRoot> where TAggregateRoot : class, IAggregateRoot, new()
{
    bool IsReadonly { get; set; }
    
    ValueTask<TAggregateRoot?> GetById(long id, CancellationToken cancellationToken);
    ValueTask<TAggregateRoot?> GetById(object[] keyValues, CancellationToken cancellationToken);
    
    Task<IReadOnlyList<TAggregateRoot>> ListAsync(CancellationToken cancellationToken);
    Task<IReadOnlyList<TAggregateRoot>> ListAsync(Expression<Func<TAggregateRoot, bool>> predicate, CancellationToken cancellationToken);
    
    Task<TAggregateRoot> SingleAsync(CancellationToken cancellationToken);
    Task<TAggregateRoot> SingleAsync(Expression<Func<TAggregateRoot, bool>> predicate, CancellationToken cancellationToken);
    
    Task<TAggregateRoot?> SingleOrDefault(CancellationToken cancellationToken);
    Task<TAggregateRoot?> SingleOrDefault(Expression<Func<TAggregateRoot, bool>> predicate, CancellationToken cancellationToken);
    
    Task<TAggregateRoot> FirstAsync(CancellationToken cancellationToken);
    Task<TAggregateRoot> FirstAsync(Expression<Func<TAggregateRoot, bool>> predicate, CancellationToken cancellationToken);
    
    Task<TAggregateRoot?> FirstOrDefaultAsync(CancellationToken cancellationToken);
    Task<TAggregateRoot?> FirstOrDefaultAsync(Expression<Func<TAggregateRoot, bool>> predicate, CancellationToken cancellationToken);

    
    Task<int> CountAsync(CancellationToken cancellationToken);
    Task<int> CountAsync(Expression<Func<TAggregateRoot, bool>> predicate, CancellationToken cancellationToken);
    
    Task<IReadOnlyList<TResult>> QueryAsync<TResult>(Func<IQueryable<TAggregateRoot>, IQueryable<TResult>> predicate, CancellationToken cancellationToken);
}