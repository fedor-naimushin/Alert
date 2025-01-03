using NotificationGateway.Core;
using NotificationGateway.Core.Models;
using Shared.Repositories.Infrastructure;

namespace NotificationGateway.DataStore.Repositories.Infrastructure;

public interface IMessageRepository : IRepository<Message>
{
}