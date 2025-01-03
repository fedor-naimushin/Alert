using MassTransit;
using NotificationGateway.Application.Models.Front;
using NotificationGateway.Application.Services;
using NotificationGateway.Core;
using NotificationGateway.Core.Infrastructure;
using NotificationGateway.Core.Infrastructure.CQS;

namespace NotificationGateway.Application.Commands;

public static class AddNotificationRequest
{
    public sealed class Command : ApiCommand<Notification>
    {
        public NotificationFront NotificationFronts { get; init; } = default!;
    }
    
    private sealed class Handler(INotificationService notificationService, IPublishEndpoint bus) : CommandHandler<Command, Notification>
    {
        public override async Task<Result<Notification>> Handle(Command request, CancellationToken cancellationToken)
        {
            var result = await notificationService.AddNotification(request.NotificationFronts, cancellationToken);

            await bus.Publish<Notification>(result, cancellationToken);
            
            return result.IsSuccess
                ? Result.Ok(result.Value)
                : Result.ToFailure(result);
        }
    }
}