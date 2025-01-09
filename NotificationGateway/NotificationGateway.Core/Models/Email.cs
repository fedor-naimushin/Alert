using Shared.Models;

namespace NotificationGateway.Core.Models;

public class Email : AlertObject, IEmail
{
    public string To { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
}