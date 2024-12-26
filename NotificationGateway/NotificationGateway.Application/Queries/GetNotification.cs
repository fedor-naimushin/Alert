using NotificationGateway.Application.Models;
using NotificationGateway.Application.Services;
using NotificationGateway.Core.Infrastructure;
using NotificationGateway.Core.Infrastructure.CQS;

namespace NotificationGateway.Application.Queries;

public static class GetNotification
{
    public sealed class Query : ApiQuery<NotificationInfo>
    {
        public long Id { get; set; }
    }
    
    private sealed class Handler(INotificationService notificationService) : QueryHandler<Query, NotificationInfo>
    {
        public override async Task<Result<NotificationInfo>> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await notificationService.GetNotification(request.Id, cancellationToken);
            return result is null 
                ? Result<NotificationInfo>.NotFound($"Уведомление с Id = {request.Id} не найдено") 
                : Result<NotificationInfo>.Ok(result);
        }
    }
}