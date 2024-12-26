using NotificationGateway.Core.Enums;

namespace NotificationGateway.Core.Errors.Infrastructure;

public interface IError
{
    ResultCode Type { get; }
    Dictionary<string, object> Data { get; }
}