using NotificationGateway.Application.Models;
using NotificationGateway.Core;
using NotificationGateway.Core.Infrastructure;
using NotificationGateway.Core.Infrastructure.CQS;
using NotificationGateway.DataStore.Repositories.Infrastructure;

namespace NotificationGateway.Application.Queries;

public static class GetNotification
{
    public sealed class Query : ApiQuery<NotificationInfo>
    {
        public long Id { get; set; }
    }
    
    private sealed class Handler(IReadonlyRepository<Notification> readonlyRepository) : QueryHandler<Query, NotificationInfo>
    {
        public override async Task<Result<NotificationInfo>> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await readonlyRepository.GetById(request.Id, cancellationToken);
            return result is null 
                ? Result<NotificationInfo>.NotFound($"Уведомление с Id = {request.Id} не найдено") 
                : Result<NotificationInfo>.Ok(NotificationInfo.FromReadonly(result));
        }
    }
}