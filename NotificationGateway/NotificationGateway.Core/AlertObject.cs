using NotificationGateway.Core.Enums;

namespace NotificationGateway.Core;

public abstract class AlertObject<TKey> : IAggregateRoot
{
    public TKey Id { get; set; }
    
    public NotificationStatus Status { get; set; } = NotificationStatus.Open;
}