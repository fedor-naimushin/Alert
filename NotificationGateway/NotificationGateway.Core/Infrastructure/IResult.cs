using NotificationGateway.Core.Enums;

namespace NotificationGateway.Core.Infrastructure;

public interface IResult
{
    string? ErrorMessage { get; }
    ResultCode Code { get; }
    bool IsSuccess { get; }
    bool IsFailure { get; }
}

public interface IResult<out T> : IResult
{
    T Value { get; }
}