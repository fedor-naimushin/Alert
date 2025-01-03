using NotificationGateway.Core;
using NotificationGateway.Core.Enums;

namespace NotificationGateway.Application.Models.Front;

public class MessageFront
{
    public string Message { get; set; }
    public string To { get; set; }

    public static Message ToAggregate(MessageFront messageFront) => new()
    {
        Text = messageFront.Message,
        To = messageFront.To
    };
}