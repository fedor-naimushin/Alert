using MassTransit;
using MessageNotifier.Application.Consumers;
using Microsoft.Extensions.DependencyInjection;
using Shared.WellKnown;

namespace MessageNotifier.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void RegisterRabbitMq(this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<MessageRequestConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(WellKnown.RabbitMqConnectionString ??  "amqp://guest:guest@localhost:5672");

                cfg.ReceiveEndpoint(WellKnown.MessagesQueue, e =>
                {
                    e.ConfigureConsumer<MessageRequestConsumer>(context);
                });
            });
        });
    }
}