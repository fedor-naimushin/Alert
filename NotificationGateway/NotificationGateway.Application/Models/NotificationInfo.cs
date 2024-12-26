using NotificationGateway.Core;
using NotificationGateway.Core.Enums;

namespace NotificationGateway.Application.Models;

public class NotificationInfo
{
    public long Id { get; set; }
    public string? Message { get; set; }
    public NotificationType Type { get; set; }

    public static NotificationInfo FromAggregate(Notification notification) => new ()
    {
        Id = notification.Id,
        Message = notification.Message,
        Type = notification.Type
    };

    public static Notification ToAggregate(NotificationInfo notificationInfo) => new()
    {
        Id = notificationInfo.Id,
        Message = notificationInfo.Message,
        Type = notificationInfo.Type
    };
}