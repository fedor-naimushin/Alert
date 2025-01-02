using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using NotificationGateway.Core.WellKnown;

namespace NotificationGateway.DataStore;

public class DbContextFactory : IDesignTimeDbContextFactory<ServerDbContext>
{
    public ServerDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ServerDbContext>();
        optionsBuilder.UseNpgsql(WellKnown.DbConnectionString);
        return new ServerDbContext(optionsBuilder.Options);
    }
}