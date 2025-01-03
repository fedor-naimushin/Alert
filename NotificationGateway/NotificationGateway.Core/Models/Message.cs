using Shared.Models;

namespace NotificationGateway.Core.Models;

public class Message : AlertObject<long>
{
    public string Text { get; set; }
    public string To { get; set; }
}