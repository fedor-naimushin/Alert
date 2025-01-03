using MassTransit;
using NotificationGateway.Application.Models;
using NotificationGateway.Application.Services;
using NotificationGateway.Core.Models;
using Shared.Infrastructure;
using Shared.Infrastructure.CQS;

namespace NotificationGateway.Application.Commands;

public static class AddMessageRequest
{
    public sealed class Command : ApiCommand<Message>
    {
        public MessageFront MessageFront { get; init; } = default!;
    }
    
    private sealed class Handler(IMessageService messageService, IPublishEndpoint bus) : CommandHandler<Command, Message>
    {
        public override async Task<Result<Message>> Handle(Command request, CancellationToken cancellationToken)
        {
            var result = await messageService.AddMessage(request.MessageFront, cancellationToken);

            await bus.Publish<Message>(result, cancellationToken);
            
            return result.IsSuccess
                ? Result.Ok(result.Value)
                : Result.ToFailure(result);
        }
    }
}