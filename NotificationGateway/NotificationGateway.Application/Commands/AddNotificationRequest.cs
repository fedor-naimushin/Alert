using NotificationGateway.Application.Models;
using NotificationGateway.Application.Models.Front;
using NotificationGateway.Application.Services;
using NotificationGateway.Core.Infrastructure;
using NotificationGateway.Core.Infrastructure.CQS;

namespace NotificationGateway.Application.Commands;

public static class AddNotificationRequest 
{
    public sealed class Command : ApiCommand<NotificationInfo>
    {
        public NotificationFront NotificationFront { get; set; } = default!;
    }
    
    private sealed class Handler(INotificationService notificationService) : CommandHandler<Command, NotificationInfo>
    {
        public override async Task<Result<NotificationInfo>> Handle(Command request, CancellationToken cancellationToken)
        {
            var newRequest = NotificationFront.ToInfo(request.NotificationFront);
            var result = await notificationService.AddNotification(newRequest, cancellationToken);
            return Result<NotificationInfo>.Ok(result);
        }
    }
}