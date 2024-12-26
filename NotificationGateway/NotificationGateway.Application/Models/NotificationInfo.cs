using NotificationGateway.Core;
using NotificationGateway.Core.Enums;

namespace NotificationGateway.Application.Models;

public class NotificationInfo
{
    public string? Message { get; set; }
    public NotificationType Type { get; set; }

    public static NotificationInfo FromReadonly(Notification notification) => new NotificationInfo()
    {
        Message = notification.Message,
        Type = notification.Type
    };
}