using NotificationGateway.Core;
using NotificationGateway.Core.Models;

namespace NotificationGateway.Application.Models;

public class EmailFront
{
    public string To { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    
    public static Email ToAggregate(EmailFront emailFront) => new()
    {
        To = emailFront.To,
        Subject = emailFront.Subject,
        Body = emailFront.Body
    };
}