namespace Shared.Models;

public interface IMessage : IAlertObject
{
    public string Text { get; set; }
    public string To { get; set; }
}