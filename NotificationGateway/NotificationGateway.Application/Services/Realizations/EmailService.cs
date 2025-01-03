using NotificationGateway.Application.Models;
using NotificationGateway.Core.Models;
using NotificationGateway.DataStore.Repositories.Infrastructure;
using Shared.Infrastructure;

namespace NotificationGateway.Application.Services.Realizations;

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