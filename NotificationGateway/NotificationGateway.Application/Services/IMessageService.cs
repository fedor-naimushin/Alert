using NotificationGateway.Application.Models.Front;
using NotificationGateway.Core;
using NotificationGateway.Core.Infrastructure;

namespace NotificationGateway.Application.Services;

public interface IMessageService
{
    Task<Result<Message>> AddMessage(MessageFront messageFront, CancellationToken cancellationToken);
}