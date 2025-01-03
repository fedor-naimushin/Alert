using NotificationGateway.Application.Models.Front;
using NotificationGateway.Core;
using NotificationGateway.Core.Infrastructure;

namespace NotificationGateway.Application.Services;

public interface INotificationService
{
    Task<Result<Notification>> AddNotification(NotificationFront notificationFront, CancellationToken cancellationToken);
}