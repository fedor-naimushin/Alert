﻿using NotificationGateway.Core.Enums;
using NotificationGateway.Core.Errors.Infrastructure;

namespace NotificationGateway.Core.Errors;

public abstract class Error : IError
{
    public abstract ResultStatus Type { get; }
    public Dictionary<string, object> Data { get; } = new();
}