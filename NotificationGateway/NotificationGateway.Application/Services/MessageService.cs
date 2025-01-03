using NotificationGateway.Application.Models.Front;
using NotificationGateway.Core;
using NotificationGateway.Core.Infrastructure;
using NotificationGateway.DataStore.Repositories.Infrastructure;

namespace NotificationGateway.Application.Services;

public class MessageService(IMessageRepository writeRepository) : IMessageService
{
    public async Task<Result<Message>> AddMessage(MessageFront messageFront, CancellationToken cancellationToken)
    {
        var newMessage = MessageFront.ToAggregate(messageFront);
        
        if (string.IsNullOrEmpty(newMessage.Text))
        {
            return Result.Fail<Message>("Текст сообщения не может быть пустым!");
        }
        
        var result = await writeRepository.AddAsync(newMessage, cancellationToken);
        await writeRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Ok(result);
    }
}