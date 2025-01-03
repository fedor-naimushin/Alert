using NotificationGateway.Core;

namespace NotificationGateway.Application.Models.Front;

public class EmailFront
{
    public string From { get; set; }
    public string To { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    
    public static Email ToAggregate(EmailFront emailFront) => new()
    {
        From = emailFront.From,
        To = emailFront.To,
        Subject = emailFront.Subject,
        Body = emailFront.Body
    };
}