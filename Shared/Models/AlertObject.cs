using NotificationGateway.Core.Enums;

namespace Shared.Models;

public abstract class AlertObject : IAlertObject
{
    public long Id { get; set; }
    public NotificationStatus Status { get; set; }
}