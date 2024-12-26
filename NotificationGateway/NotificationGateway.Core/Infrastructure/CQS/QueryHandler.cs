using NotificationGateway.Core.Infrastructure.CQS.Infrastructure;

namespace NotificationGateway.Core.Infrastructure.CQS;

public abstract class QueryHandler<TQuery, TResult> : HandleBase<TQuery, Result<TResult>>, IQueryHandler<TQuery, Result<TResult>>
    where TQuery : ApiQuery<TResult>
{
    protected Result Ok() => Result.Ok();
    protected Result<TResult> Ok(TResult result) => Result<TResult>.Ok(result);

    protected Result Fail() => Result.Fail();
    protected Result<TResult> Fail(TResult result) => Result<TResult>.Fail(result);
}