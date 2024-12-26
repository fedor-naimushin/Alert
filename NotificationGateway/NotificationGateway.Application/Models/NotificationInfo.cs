using NotificationGateway.Application.Models.Front;
using NotificationGateway.Core;

namespace NotificationGateway.Application.Models;

public class NotificationInfo : NotificationFront
{
    public long Id { get; set; }
    
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