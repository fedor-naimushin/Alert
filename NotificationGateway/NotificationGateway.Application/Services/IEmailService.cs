using NotificationGateway.Application.Models;
using NotificationGateway.Core.Models;
using Shared.Infrastructure;

namespace NotificationGateway.Application.Services;

public interface IEmailService
{
    Task<Result<Email>> AddEmail(EmailFront emailFront, CancellationToken cancellationToken);
}