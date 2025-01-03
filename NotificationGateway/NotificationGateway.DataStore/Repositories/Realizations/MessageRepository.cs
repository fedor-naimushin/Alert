using NotificationGateway.Core;
using NotificationGateway.DataStore.Repositories.Infrastructure;

namespace NotificationGateway.DataStore.Repositories.Realizations;

public class MessageRepository(ServerDbContext context) : EFRepository<Message, ServerDbContext>(context), IMessageRepository;