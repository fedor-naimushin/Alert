using NotificationGateway.Application.Models;
using NotificationGateway.Core.Models;
using NotificationGateway.DataStore.Repositories;
using Shared.Infrastructure;
using Shared.Repositories;

namespace NotificationGateway.Application.Services.Realizations;

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