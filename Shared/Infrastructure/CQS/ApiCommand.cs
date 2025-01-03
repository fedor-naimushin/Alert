using MediatR;
using Shared.Infrastructure.CQS.Infrastructure;

namespace Shared.Infrastructure.CQS;

public abstract class ApiCommand : IRequest<Result>, ICommand
{
}

public abstract class ApiCommand<TResult> : IRequest<Result<TResult>>, ICommand<Result<TResult>>
{
}