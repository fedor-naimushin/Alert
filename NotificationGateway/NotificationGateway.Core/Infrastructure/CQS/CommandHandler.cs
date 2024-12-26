using NotificationGateway.Core.Infrastructure.CQS.Infrastructure;

namespace NotificationGateway.Core.Infrastructure.CQS;

public abstract class CommandHandler<TCommand> : HandleBase<TCommand, Result>, ICommandHandler<TCommand>
    where TCommand : ApiCommand
{
    protected Result Ok() => Result.Ok();
    protected Result Fail() => Result.Fail();
}