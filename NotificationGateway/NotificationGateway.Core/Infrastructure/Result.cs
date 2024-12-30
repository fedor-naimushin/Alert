using NotificationGateway.Core.Enums;

namespace NotificationGateway.Core.Infrastructure;

public class Result : IResult
{
    public bool IsSuccess { get; protected init; }
    public bool IsFailure => !IsSuccess;
    
    public string? ErrorMessage { get; protected init; }
    public ResultCode Status { get; protected init; }
    
    public static Result Ok() => new()
    {
        IsSuccess = true,
        Status = ResultCode.Ok
    };

    public static Result Fail() => new()
    {
        IsSuccess = false,
        Status = ResultCode.Fail
    };
    
    public static Result NotFound() => new()
    {
        IsSuccess = false,
        Status = ResultCode.NotFound
    };
}

public class Result<TValue> : Result, IResult<TValue>
{
    public TValue Value { get; } = default!;

    private Result(TValue value)
    {
        Value = value;
    }

    private Result()
    {
    }

    public static Result<TValue> Ok(TValue value) => new(value)
    {
        IsSuccess = true,
        Status = ResultCode.Ok
    };

    public static Result<TValue> Fail(TValue value) => new(value)
    {
        IsSuccess = false,
        Status = ResultCode.Fail
    };

    public static Result<TValue> NotFound(string message) => new()
    {
        IsSuccess = false,
        Status = ResultCode.NotFound,
        ErrorMessage = message
    };
}