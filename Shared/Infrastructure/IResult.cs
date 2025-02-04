﻿using Shared.Enums;

namespace Shared.Infrastructure;

public interface IResult
{
    string? ErrorMessage { get; }
    ResultCode Status { get; }
    bool IsSuccess { get; }
    bool IsFailure { get; }
}

public interface IResult<out T> : IResult
{
    T Value { get; }
}