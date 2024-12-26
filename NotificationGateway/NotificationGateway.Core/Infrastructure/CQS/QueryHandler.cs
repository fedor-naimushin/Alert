using NotificationGateway.Core.Infrastructure.CQS.Infrastructure;

namespace NotificationGateway.Core.Infrastructure.CQS;

public abstract class QueryHandler<TQuery, TResult> : HandleBase<TQuery, Result<TResult>>, IQueryHandler<TQuery, Result<TResult>>
    where TQuery : ApiQuery<TResult>
{
}