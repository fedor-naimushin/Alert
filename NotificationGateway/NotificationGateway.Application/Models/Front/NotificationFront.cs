using NotificationGateway.Core.Enums;

namespace NotificationGateway.Application.Models.Front;

public class NotificationFront
{
    public string? Message { get; set; }
    public NotificationType Type { get; set; }

    public static NotificationInfo ToInfo(NotificationFront notificationFront) => new()
    {
        Message = notificationFront.Message,
        Type = notificationFront.Type
    };
}