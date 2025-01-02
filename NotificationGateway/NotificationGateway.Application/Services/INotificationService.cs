using NotificationGateway.Application.Models.Front;

namespace NotificationGateway.Application.Services;

public interface INotificationService
{
    Task<int> AddNotifications(IReadOnlyList<NotificationFront> notificationFronts, CancellationToken cancellationToken);
}