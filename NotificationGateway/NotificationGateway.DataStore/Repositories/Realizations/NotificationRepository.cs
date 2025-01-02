using NotificationGateway.Core;
using NotificationGateway.DataStore.Repositories.Infrastructure;

namespace NotificationGateway.DataStore.Repositories.Realizations;

public class NotificationRepository(ServerDbContext context) : EFRepository<Notification, ServerDbContext>(context), INotificationRepository;