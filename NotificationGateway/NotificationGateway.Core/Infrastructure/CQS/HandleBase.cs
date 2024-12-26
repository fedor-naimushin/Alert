﻿using System.Runtime;
using MediatR;

namespace NotificationGateway.Core.Infrastructure.CQS;

public abstract class HandleBase<T, TResult> : IRequestHandler<T, TResult> 
    where T : IRequest<TResult>
    where TResult : class, IResult
{
    async Task<TResult> IRequestHandler<T, TResult>.Handle(T request, CancellationToken cancellationToken)
    {
        var result = await CoreHandle(request, cancellationToken);
        return (TResult) result;
    }
    
    public abstract Task<TResult> Handle(T request, CancellationToken cancellationToken);

    protected virtual async Task<IResult> CoreHandle(T request, CancellationToken cancellationToken)
    {
        var canHandle = await CanHandle(request, cancellationToken);
        if (canHandle.IsFailure)
        {
            return canHandle;
        }

        return await Handle(request, cancellationToken);
    }

    protected virtual Task<Result> CanHandle(T request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Ok());
    }
}