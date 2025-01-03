using Shared.Enums;

namespace Shared.Infrastructure;

public class Result : IResult
{
    protected Result()
    {
    }
    
    public bool IsSuccess { get; private init; }
    public bool IsFailure => !IsSuccess;
    
    public string? ErrorMessage { get; private init; }
    public ResultCode Status { get; private init; }
    
    public static Result Ok() => new()
    {
        IsSuccess = true,
        Status = ResultCode.Ok
    };

    public static Result<T> Ok<T>(T value) => new(value)
    {
        IsSuccess = true,
        Status = ResultCode.Ok
    };

    public static Result Fail() => new()
    {
        IsSuccess = false,
        Status = ResultCode.Fail
    };
    
    public static Result<string> Fail(string message) => new(message)
    {
        IsSuccess = false,
        Status = ResultCode.Fail,
        ErrorMessage = message
    };
    
    public static Result<T> Fail<T>(string message) => new()
    {
        IsSuccess = false,
        Status = ResultCode.Fail,
        ErrorMessage = message
        
    };
    
    public static Result<string> NotFound(string message) => new(message)
    {
        IsSuccess = false,
        Status = ResultCode.NotFound,
        ErrorMessage = message
    };
    
    public static Result<T> ToFailure<T>(Result<T> result) => new(result.Value)
    {
        IsSuccess = false,
        ErrorMessage = result.ErrorMessage,
        Status = result.Status
    };
}

public class Result<TValue> : Result, IResult<TValue>
{
    public TValue Value { get; }

    internal Result(TValue value)
    {
        Value = value;
    }

    internal Result()
    {
    }
}