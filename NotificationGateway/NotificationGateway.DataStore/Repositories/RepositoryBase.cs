using NotificationGateway.Core;
using NotificationGateway.DataStore.Repositories.Infrastructure;

namespace NotificationGateway.DataStore.Repositories;

public abstract class RepositoryBase<TAggregateRoot>(IUnitOfWork unitOfWork) : ReadonlyRepositoryBase<TAggregateRoot>, IRepository<TAggregateRoot> where TAggregateRoot : class, IAggregateRoot
{
    public IUnitOfWork UnitOfWork { get; } = unitOfWork;
    
    public abstract Task<TAggregateRoot> AddAsync(TAggregateRoot aggregateRoot, CancellationToken cancellationToken);
    public abstract Task<IReadOnlyList<TAggregateRoot>> AddRangeAsync(IReadOnlyList<TAggregateRoot> aggregateRoots, CancellationToken cancellationToken);
    
    public abstract Task RemoveRangeAsync(IReadOnlyList<TAggregateRoot> aggregateRoot, CancellationToken cancellationToken);
    public abstract Task RemoveAsync(TAggregateRoot aggregateRoot, CancellationToken cancellationToken);
}