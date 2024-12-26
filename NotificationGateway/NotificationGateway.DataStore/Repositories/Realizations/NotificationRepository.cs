using NotificationGateway.Core;
using NotificationGateway.DataStore.Repositories.Infrastructure;

namespace NotificationGateway.DataStore.Repositories.Realizations;

public class NotificationRepository : EFRepository<Notification, ServerDbContext>, INotificationRepository
{
    public NotificationRepository(ServerDbContext context) : base(context)
    {
        
    }
    
}