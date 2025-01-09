namespace Shared.Models;

public interface IAlertObject : IEntity<long>, IStatusObject, IAggregateRoot
{
}