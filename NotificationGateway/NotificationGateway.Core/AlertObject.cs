namespace NotificationGateway.Core;

public abstract class AlertObject<TKey> : Entity
{
    public TKey Id { get; set; }
}