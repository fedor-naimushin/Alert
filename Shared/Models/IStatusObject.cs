using NotificationGateway.Core.Enums;

namespace Shared.Models;

public interface IStatusObject
{
    public NotificationStatus Status { get; set; }
}