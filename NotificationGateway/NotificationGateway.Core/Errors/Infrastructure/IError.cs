using NotificationGateway.Core.Enums;

namespace NotificationGateway.Core.Errors.Infrastructure;

public interface IError
{
    ResultStatus Type { get; }
    Dictionary<string, object> Data { get; }
}