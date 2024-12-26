using NotificationGateway.Application.Models;

namespace NotificationGateway.Application.Services;

public interface INotificationService
{
    Task<NotificationInfo?> GetNotification(long id, CancellationToken cancellationToken);
    Task<NotificationInfo> AddNotification(NotificationInfo notificationInfo, CancellationToken cancellationToken);
}