using NotificationGateway.Core.Enums;

namespace Shared.Models;

public abstract class AlertObject<TKey> : IEntity<TKey>, IStatusObject, IAggregateRoot
{
    public TKey Id { get; set; }
    public NotificationStatus Status { get; set; }
}