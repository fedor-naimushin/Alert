using Microsoft.Extensions.DependencyInjection;
using NotificationGateway.DataStore.Repositories.Extensions;
using NotificationGateway.DataStore.Repositories.Infrastructure;
using NotificationGateway.DataStore.Repositories.Realizations;

namespace NotificationGateway.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void RegisterRepositories(this IServiceCollection services)
    {
        services.RegisterRepository<INotificationRepository, NotificationRepository>();
    }
}