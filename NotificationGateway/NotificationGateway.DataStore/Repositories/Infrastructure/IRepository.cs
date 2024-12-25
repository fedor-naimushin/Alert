using NotificationGateway.Core;

namespace NotificationGateway.DataStore.Repositories.Infrastructure;

public interface IRepository<TAggregateRoot> : IReadonlyRepository<TAggregateRoot> where TAggregateRoot : class, IAggregateRoot, new()
{
    Task<TAggregateRoot> AddAsync(TAggregateRoot aggregateRoot, CancellationToken cancellationToken);
    Task AddRangeAsync(IReadOnlyList<TAggregateRoot> aggregateRoots, CancellationToken cancellationToken);
    
    Task RemoveRangeAsync(IReadOnlyList<TAggregateRoot>  aggregateRoots, CancellationToken cancellationToken);
    Task RemoveAsync(TAggregateRoot aggregateRoot, CancellationToken cancellationToken);
    
    IUnitOfWork UnitOfWork { get; }
}