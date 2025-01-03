using NotificationGateway.Core.Models;
using Shared.Repositories;

namespace NotificationGateway.DataStore.Repositories;

public class MessageRepository(ServerDbContext context) : EFRepository<Message, ServerDbContext>(context), IMessageRepository;