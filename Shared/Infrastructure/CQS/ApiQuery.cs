using MediatR;
using Shared.Infrastructure.CQS.Infrastructure;

namespace Shared.Infrastructure.CQS;

public abstract class ApiQuery<TResult> : IQuery<Result<TResult>>, IRequest<Result<TResult>>
{
}