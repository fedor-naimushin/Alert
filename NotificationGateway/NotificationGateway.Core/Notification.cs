using NotificationGateway.Core.Enums;

namespace NotificationGateway.Core;

public class Notification : AlertObject<long>, IAggregateRoot
{
    public string? Message { get; set; }
    public NotificationType Type { get; set; }

    public NotificationStatus Status { get; set; } = NotificationStatus.Open;
}