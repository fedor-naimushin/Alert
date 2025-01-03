using Shared.Infrastructure.CQS.Infrastructure;

namespace Shared.Infrastructure.CQS;

public abstract class CommandHandler<TCommand> : HandleBase<TCommand, Result>, ICommandHandler<TCommand>
    where TCommand : ApiCommand
{
}

public abstract class CommandHandler<TCommand, TResult> : HandleBase<TCommand, Result<TResult>>,
    ICommandHandler<TCommand, Result<TResult>>
    where TCommand : ApiCommand<TResult>
{
}