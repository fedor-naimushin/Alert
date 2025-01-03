using MassTransit;
using Shared.Models;

namespace MessageNotifier.Application.Consumers;

public class MessageRequestConsumer(IBus bus) : IConsumer<IMessage>
{
    public Task Consume(ConsumeContext<IMessage> context)
    {
        throw new NotImplementedException();
    }
}