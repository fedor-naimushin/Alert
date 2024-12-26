using MediatR;
using NotificationGateway.Core.Infrastructure.CQS.Infrastructure;

namespace NotificationGateway.Core.Infrastructure.CQS;

public abstract class ApiQuery<TResult> : IQuery<Result<TResult>>, IRequest<Result<TResult>>
{
}