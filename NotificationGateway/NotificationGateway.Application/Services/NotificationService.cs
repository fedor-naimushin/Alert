using NotificationGateway.Application.Models.Front;
using NotificationGateway.Core;
using NotificationGateway.DataStore.Repositories.Infrastructure;

namespace NotificationGateway.Application.Services;

public class NotificationService(
    INotificationRepository writeRepository,
    IReadonlyRepository<Notification> readRepository) : INotificationService
{
    public async Task<int> AddNotifications(IReadOnlyList<NotificationFront> notificationFronts, CancellationToken cancellationToken)
    {
        var newNotifications = notificationFronts
            .Select(NotificationFront.ToAggregate)
            .ToList();
        var result = await writeRepository.AddRangeAsync(newNotifications, cancellationToken);
        await writeRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return result;
    }
}