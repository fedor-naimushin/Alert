using NotificationGateway.Application.Models.Front;
using NotificationGateway.Core;
using NotificationGateway.Core.Infrastructure;
using NotificationGateway.DataStore.Repositories.Infrastructure;

namespace NotificationGateway.Application.Services;

public class NotificationService(INotificationRepository writeRepository) : INotificationService
{
    public async Task<Result<Notification>> AddNotification(NotificationFront notificationFront, CancellationToken cancellationToken)
    {
        var newNotification = NotificationFront.ToAggregate(notificationFront);
        
        if (newNotification.Message is null)
        {
            return Result.Fail<Notification>("Текст сообщения не может быть пустым!");
        }
        
        var result = await writeRepository.AddAsync(newNotification, cancellationToken);
        await writeRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Ok(result);
    }
}