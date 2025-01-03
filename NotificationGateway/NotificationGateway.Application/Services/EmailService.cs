using NotificationGateway.Application.Models.Front;
using NotificationGateway.Core;
using NotificationGateway.Core.Infrastructure;
using NotificationGateway.DataStore.Repositories.Infrastructure;

namespace NotificationGateway.Application.Services;

public class EmailService(IEmailRepository writeRepository) : IEmailService
{
    public async Task<Result<Email>> AddEmail(EmailFront emailFront, CancellationToken cancellationToken)
    {
        var newEmail = EmailFront.ToAggregate(emailFront);
        
        if (string.IsNullOrEmpty(newEmail.Body))
        {
            return Result.Fail<Email>("Текст сообщения не может быть пустым!");
        }
        
        var result = await writeRepository.AddAsync(newEmail, cancellationToken);
        await writeRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Ok(result);
    }
}