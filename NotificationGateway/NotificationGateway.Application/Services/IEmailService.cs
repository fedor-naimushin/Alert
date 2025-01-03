using NotificationGateway.Application.Models.Front;
using NotificationGateway.Core;
using NotificationGateway.Core.Infrastructure;

namespace NotificationGateway.Application.Services;

public interface IEmailService
{
    Task<Result<Email>> AddEmail(EmailFront emailFront, CancellationToken cancellationToken);
}