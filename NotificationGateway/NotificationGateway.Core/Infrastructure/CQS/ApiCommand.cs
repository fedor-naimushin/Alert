using MediatR;
using NotificationGateway.Core.Infrastructure.CQS.Infrastructure;

namespace NotificationGateway.Core.Infrastructure.CQS;

public abstract class ApiCommand : IRequest<Result>, ICommand
{
}