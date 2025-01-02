using NotificationGateway.Application.Models;
using NotificationGateway.Application.Models.Front;
using NotificationGateway.Application.Services;
using NotificationGateway.Core.Infrastructure;
using NotificationGateway.Core.Infrastructure.CQS;

namespace NotificationGateway.Application.Commands;

public static class AddNotificationRequests
{
    public sealed class Command : ApiCommand<int>
    {
        public IReadOnlyList<NotificationFront> NotificationFronts { get; init; } = default!;
    }
    
    private sealed class Handler(INotificationService notificationService) : CommandHandler<Command, int>
    {
        public override async Task<Result<int>> Handle(Command request, CancellationToken cancellationToken)
        {
            var newRequests = request.NotificationFronts;
            var result = await notificationService.AddNotifications(newRequests, cancellationToken);
            return Result<int>.Ok(result);
        }
    }
}