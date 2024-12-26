using NotificationGateway.Core.Enums;

namespace NotificationGateway.Core.Infrastructure;

public class Result : IResult
{
    public bool IsSuccess { get; protected init; }
    public bool IsFailure => !IsSuccess;
    
    public string? ErrorMessage { get; protected init; }
    public ResultCode Code { get; protected init; }
    
    public static Result Ok() => new()
    {
        IsSuccess = true,
        Code = ResultCode.Ok
    };

    public static Result Fail() => new()
    {
        IsSuccess = false,
        Code = ResultCode.Fail
    };
    
    public static Result NotFound() => new()
    {
        IsSuccess = false,
        Code = ResultCode.NotFound
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
        Code = ResultCode.Ok
    };

    public static Result<TValue> Fail(TValue value) => new(value)
    {
        IsSuccess = false,
        Code = ResultCode.Fail
    };

    public static Result<TValue> NotFound(string message) => new()
    {
        IsSuccess = false,
        Code = ResultCode.NotFound,
        ErrorMessage = message
    };
}