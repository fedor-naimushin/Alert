using NotificationGateway.Core.Enums;

namespace Shared.Models;

public abstract class AlertObject<TKey> : IAggregateRoot
{
    public TKey Id { get; set; }
    
    public NotificationStatus Status { get; set; } = NotificationStatus.Open;
}