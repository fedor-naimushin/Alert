using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NotificationGateway.Application.Services;
using NotificationGateway.Application.Services.Realizations;
using NotificationGateway.Core.Models;
using NotificationGateway.DataStore;
using NotificationGateway.DataStore.Extensions;
using NotificationGateway.DataStore.Repositories;
using Shared.WellKnown;

namespace NotificationGateway.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void RegisterWellKnows(this IServiceCollection services, IConfiguration configuration)
    {
        WellKnown.Initialize(configuration);
    }
    
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
            options.UseNpgsql(WellKnown.DbConnectionString);
        });
    }

    public static void RegisterRabbitMq(this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                var rabbitMqConnectionString = WellKnown.RabbitMqConnectionString;

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
}