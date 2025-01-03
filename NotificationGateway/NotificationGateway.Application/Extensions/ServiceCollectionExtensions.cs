using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NotificationGateway.Application.Services;
using NotificationGateway.Application.Services.Realizations;
using NotificationGateway.Core;
using NotificationGateway.Core.Models;
using NotificationGateway.DataStore;
using NotificationGateway.DataStore.Extensions;
using NotificationGateway.DataStore.Repositories.Infrastructure;
using NotificationGateway.DataStore.Repositories.Realizations;
using Shared.WellKnown;

namespace NotificationGateway.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void RegisterCQS(this IServiceCollection services)
    {
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));
        }
    }
    
    public static void ResisterServices(this IServiceCollection services)
    {
        services.AddScoped<IMessageService, MessageService>();
        services.AddScoped<IEmailService, EmailService>();
    }
    
    public static void RegisterRepositories(this IServiceCollection services)
    {
        services.RegisterRepository<IMessageRepository, MessageRepository>();
        services.RegisterRepository<IEmailRepository, EmailRepository>();
    }

    public static void RegisterDbContext(this IServiceCollection services)
    {
        services.AddDbContext<ServerDbContext>(options =>
        {
            options.UseNpgsql(WellKnown.DbConnectionString ?? "Host=localhost;Port=5432;Database=Alert;User ID=postgres;Password=postgres;");
        });
    }

    public static void ResisterRabbitMq(this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                var rabbitMqConnectionString = WellKnown.RabbitMqConnectionString ??  "amqp://guest:guest@localhost:5672";

                cfg.Host(new Uri(rabbitMqConnectionString));
                
                cfg.Message<Message>(config =>
                {
                    config.SetEntityName(WellKnown.MessagesQueue);
                });
                
                cfg.Message<Email>(config =>
                {
                    config.SetEntityName(WellKnown.EmailsQueue);
                });
            });
        });
    }

    public static void RegisterMigrations(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ServerDbContext>();
        dbContext.Database.Migrate();
    }
}