namespace NotificationGateway.Core;

public abstract class AlertObject<TKey> : Entity
{
    public required TKey Id { get; set; }
}