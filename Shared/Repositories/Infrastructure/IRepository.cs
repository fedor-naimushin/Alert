using Shared.Models;

namespace Shared.Repositories.Infrastructure;

public interface IRepository<TAggregateRoot> : IReadonlyRepository<TAggregateRoot> where TAggregateRoot : class, IAggregateRoot
{
    Task<TAggregateRoot> AddAsync(TAggregateRoot aggregateRoot, CancellationToken cancellationToken);
    Task<int> AddRangeAsync(IReadOnlyList<TAggregateRoot> aggregateRoots, CancellationToken cancellationToken);
    
    Task RemoveRangeAsync(IReadOnlyList<TAggregateRoot>  aggregateRoots, CancellationToken cancellationToken);
    Task RemoveAsync(TAggregateRoot aggregateRoot, CancellationToken cancellationToken);
    
    IUnitOfWork UnitOfWork { get; }
}