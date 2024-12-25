using System.Data;
using NotificationGateway.Core;
using NotificationGateway.DataStore.Repositories.Infrastructure;

namespace NotificationGateway.DataStore.Repositories;

public abstract class RepositoryBase<TAggregateRoot>(IUnitOfWork unitOfWork) : ReadonlyRepositoryBase<TAggregateRoot>, IRepository<TAggregateRoot> 
    where TAggregateRoot : class, IAggregateRoot
{
    public IUnitOfWork UnitOfWork
    {
        get
        {
            if (IsReadonly)
            {
                throw new ReadOnlyException("Repository is readonly");
            }
            
            return unitOfWork;
        }
    }

    public abstract Task<TAggregateRoot> AddAsync(TAggregateRoot aggregateRoot, CancellationToken cancellationToken);
    public abstract Task AddRangeAsync(IReadOnlyList<TAggregateRoot> aggregateRoots, CancellationToken cancellationToken);
    
    public abstract Task RemoveRangeAsync(IReadOnlyList<TAggregateRoot> aggregateRoots, CancellationToken cancellationToken);
    public abstract Task RemoveAsync(TAggregateRoot aggregateRoot, CancellationToken cancellationToken);
}