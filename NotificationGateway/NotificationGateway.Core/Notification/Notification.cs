namespace NotificationGateway.Core.Notification;

public class Notification : AlertObject<long>, IAggregateRoot
{
    public string? Message { get; set; }
    public NotificationType Type { get; set; }
}