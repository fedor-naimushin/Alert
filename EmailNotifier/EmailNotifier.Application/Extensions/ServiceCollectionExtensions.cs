
using EmailNotifier.Application.Consumers;
using EmailNotifier.Application.Models;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.WellKnown;

namespace EmailNotifier.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void RegisterRabbitMq(this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<EmailRequestConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(WellKnown.RabbitMqConnectionString);

                cfg.ReceiveEndpoint(WellKnown.MessagesQueue, e =>
                {
                    e.ConfigureConsumer<EmailRequestConsumer>(context);
                });
            });
        });
    }
}