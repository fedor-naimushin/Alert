namespace NotificationGateway.Core;

public class Message : AlertObject<long>
{
    public string Text { get; set; }
    public string To { get; set; }
}