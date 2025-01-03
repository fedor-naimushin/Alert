using NotificationGateway.Application.Models;
using NotificationGateway.Core.Models;
using Shared.Infrastructure;

namespace NotificationGateway.Application.Services;

public interface IMessageService
{
    Task<Result<Message>> AddMessage(MessageFront messageFront, CancellationToken cancellationToken);
}