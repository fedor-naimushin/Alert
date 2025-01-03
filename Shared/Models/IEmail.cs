namespace Shared.Models;

public interface IEmail : IEntity<long>, IStatusObject, IAggregateRoot
{
    public string From { get; set; }
    public string To { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
}