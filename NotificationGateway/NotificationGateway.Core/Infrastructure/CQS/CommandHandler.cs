using NotificationGateway.Core.Infrastructure.CQS.Infrastructure;

namespace NotificationGateway.Core.Infrastructure.CQS;

public abstract class CommandHandler<TCommand> : HandleBase<TCommand, Result>, ICommandHandler<TCommand>
    where TCommand : ApiCommand
{
}

public abstract class CommandHandler<TCommand, TResult> : HandleBase<TCommand, Result<TResult>>,
    ICommandHandler<TCommand, Result<TResult>>
    where TCommand : ApiCommand<TResult>
{
}