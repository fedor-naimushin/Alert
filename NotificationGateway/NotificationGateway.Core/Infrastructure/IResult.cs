using NotificationGateway.Core.Enums;

namespace NotificationGateway.Core.Infrastructure;

public interface IResult
{
    string Message { get; }
    ResultStatus Status { get; }
    bool IsSuccess { get; }
    bool IsFailure { get; }
}

public interface IResult<out T> : IResult
{
    T Value { get; }
}