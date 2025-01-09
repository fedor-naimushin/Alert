using Shared.Models;

namespace NotificationGateway.Core.Models;

public class Message : AlertObject, IMessage
{
    public string Text { get; set; }
    public string To { get; set; }
}