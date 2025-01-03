using Shared.Infrastructure;
using Shared.Models;

namespace MessageNotifier.Application.Services;

public interface IMessageService
{
    Task<Result<IMessage>> SendMessage(string toPhoneNumber, string message);
    
}