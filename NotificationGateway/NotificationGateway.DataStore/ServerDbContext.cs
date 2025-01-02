using Microsoft.EntityFrameworkCore;
using NotificationGateway.Core;
using NotificationGateway.DataStore.Repositories.Infrastructure;

namespace NotificationGateway.DataStore;

public class ServerDbContext(DbContextOptions<ServerDbContext> contextOptions) : DbContext(contextOptions), IUnitOfWork
{
    public DbSet<Notification> Notifications { get; set; }
}