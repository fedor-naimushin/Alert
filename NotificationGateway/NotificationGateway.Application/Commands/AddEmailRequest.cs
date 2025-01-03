using MassTransit;
using NotificationGateway.Application.Models;
using NotificationGateway.Application.Services;
using NotificationGateway.Core.Models;
using Shared.Infrastructure;
using Shared.Infrastructure.CQS;

namespace NotificationGateway.Application.Commands;

public static class AddEmailRequest
{
    public sealed class Command : ApiCommand<Email>
    {
        public EmailFront EmailFront { get; set; }
    }
    
    private sealed class Handler(IEmailService emailService, IPublishEndpoint bus) : CommandHandler<Command, Email>
    {
        public override async Task<Result<Email>> Handle(Command request, CancellationToken cancellationToken)
        {
            var result = await emailService.AddEmail(request.EmailFront, cancellationToken);

            await bus.Publish<Email>(result, cancellationToken);
            
            return result.IsSuccess
                ? Result.Ok(result.Value)
                : Result.ToFailure(result);
        }
    }
}