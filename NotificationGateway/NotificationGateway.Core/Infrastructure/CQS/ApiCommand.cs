using MediatR;
using NotificationGateway.Core.Infrastructure.CQS.Infrastructure;

namespace NotificationGateway.Core.Infrastructure.CQS;

public abstract class ApiCommand : IRequest<Result>, ICommand
{
}

public abstract class ApiCommand<TResult> : IRequest<Result<TResult>>, ICommand<Result<TResult>>
{
}