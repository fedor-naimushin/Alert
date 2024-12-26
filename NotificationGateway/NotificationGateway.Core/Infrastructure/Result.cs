using NotificationGateway.Core.Enums;
using NotificationGateway.Core.Infrastructure.CQS;

namespace NotificationGateway.Core.Infrastructure;

public class Result : IResult
{
    public bool IsSuccess { get; protected init; }
    public bool IsFailure => !IsSuccess;
    
    public string Message { get; protected init; }
    public ResultStatus Status { get; protected init; }
    
    protected Result()
    {
    }

    public static Result Ok() => new()
    {
        IsSuccess = true,
        Status = ResultStatus.Ok
    };

    public static Result Fail() => new()
    {
        IsSuccess = false,
        Status = ResultStatus.Fail
    };
    
    public static Result NotFound() => new()
    {
        IsSuccess = false,
        Status = ResultStatus.NotFound
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
        Status = ResultStatus.Ok
    };

    public static Result<TValue> Fail(TValue value) => new(value)
    {
        IsSuccess = false,
        Status = ResultStatus.Fail
    };

    public new static Result<TValue> NotFound(string message) => new()
    {
        IsSuccess = false,
        Status = ResultStatus.NotFound,
        Message = message
    };
}