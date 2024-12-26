namespace NotificationGateway.Core.Infrastructure.CQS.Infrastructure;

public interface ICommandHandler<in TCommand> where TCommand : ICommand
{
    Task<Result> Handle(TCommand command, CancellationToken cancellationToken);
}