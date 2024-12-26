using NotificationGateway.Application.Extensions;
using NotificationGateway.Application.Models;
using NotificationGateway.Core;
using NotificationGateway.DataStore.Repositories.Infrastructure;

namespace NotificationGateway.Application.Services;

public class NotificationService(
    INotificationRepository writeRepository,
    IReadonlyRepository<Notification> readRepository) : INotificationService
{
    public async Task<NotificationInfo?> GetNotification(long id, CancellationToken cancellationToken)
    {
        var result = await readRepository.GetById(id, cancellationToken);
        return result is not null
            ? NotificationInfo.FromAggregate(result)
            : null;
    }

    public async Task<NotificationInfo> AddNotification(NotificationInfo notificationInfo,
        CancellationToken cancellationToken)
    {
        var result = await writeRepository.AddAsync(NotificationInfo.ToAggregate(notificationInfo), cancellationToken);
        await writeRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return NotificationInfo.FromAggregate(result);
    }
}