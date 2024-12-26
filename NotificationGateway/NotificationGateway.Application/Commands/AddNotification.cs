using NotificationGateway.Application.Models;
using NotificationGateway.Application.Services;
using NotificationGateway.Core.Infrastructure;
using NotificationGateway.Core.Infrastructure.CQS;

namespace NotificationGateway.Application.Commands;

public static class AddNotification 
{
    public sealed class Command : ApiCommand<NotificationInfo>
    {
        public NotificationInfo NotificationInfo { get; set; } = default!;
    }
    
    private sealed class Handler(INotificationService notificationService) : CommandHandler<Command, NotificationInfo>
    {
        public override async Task<Result<NotificationInfo>> Handle(Command request, CancellationToken cancellationToken)
        {
            var result = await notificationService.AddNotification(request.NotificationInfo, cancellationToken);
            return Result<NotificationInfo>.Ok(result);
        }
    }
}