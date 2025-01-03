namespace Shared.Models;

public interface IMessage : IEntity<long>, IStatusObject, IAggregateRoot
{
    public string Text { get; set; }
    public string To { get; set; }
}