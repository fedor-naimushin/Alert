using Microsoft.EntityFrameworkCore;
using NotificationGateway.Core.Notification;
using NotificationGateway.DataStore.Repositories.Infrastructure;

namespace NotificationGateway.DataStore;

public class ServerDbContext : DbContext, IUnitOfWork
{
    public DbSet<Notification> Notifications { get; set; }
}