using MassTransit;
using MessageNotifier.Application.Models;
using Microsoft.Extensions.Options;
using Shared.Models;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace MessageNotifier.Application.Consumers;

public class MessageRequestConsumer(IOptions<Auth> options) : IConsumer<IMessage>
{
    private readonly string _accountSid = options.Value.AccountSid;
    private readonly string _authToken = options.Value.AuthToken;
    private readonly string _fromNumber = options.Value.FromPhoneNumber;

    public async Task Consume(ConsumeContext<IMessage> context)
    {
        TwilioClient.Init(_accountSid, _authToken);

        await MessageResource.CreateAsync(
            body: context.Message.Text,
            from: new PhoneNumber(_fromNumber),
            to: new PhoneNumber(context.Message.To)
        );
    }
}