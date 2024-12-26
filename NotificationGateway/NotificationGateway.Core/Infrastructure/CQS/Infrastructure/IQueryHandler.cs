namespace NotificationGateway.Core.Infrastructure.CQS.Infrastructure;

internal interface IQueryHandler<in TQuery, TResult> where TQuery : IQuery<TResult>
{
    Task<TResult> Handle(TQuery query, CancellationToken cancellationToken);
}