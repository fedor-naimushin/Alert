using Shared.Infrastructure.CQS.Infrastructure;

namespace Shared.Infrastructure.CQS;

public abstract class QueryHandler<TQuery, TResult> : HandleBase<TQuery, Result<TResult>>, IQueryHandler<TQuery, Result<TResult>>
    where TQuery : ApiQuery<TResult>
{
}