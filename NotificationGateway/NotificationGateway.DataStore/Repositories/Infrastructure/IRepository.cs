using NotificationGateway.Core;

namespace NotificationGateway.DataStore.Repositories.Infrastructure;

public interface IRepository<TAggregateRoot> : IReadonlyRepository<TAggregateRoot> where TAggregateRoot : IAggregateRoot
{
    Task<TAggregateRoot> AddAsync(TAggregateRoot aggregateRoot, CancellationToken cancellationToken);
    Task<IReadOnlyList<TAggregateRoot>> AddRangeAsync(IReadOnlyList<TAggregateRoot> aggregateRoots, CancellationToken cancellationToken);
    
    Task RemoveRangeAsync(IReadOnlyList<TAggregateRoot>  aggregateRoot, CancellationToken cancellationToken);
    Task RemoveAsync(TAggregateRoot aggregateRoot, CancellationToken cancellationToken);
    
    IUnitOfWork UnitOfWork { get; }
}