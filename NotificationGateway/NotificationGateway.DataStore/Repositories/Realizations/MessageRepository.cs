using NotificationGateway.Core;
using NotificationGateway.Core.Models;
using NotificationGateway.DataStore.Repositories.Infrastructure;
using Shared.Repositories;

namespace NotificationGateway.DataStore.Repositories.Realizations;

public class MessageRepository(ServerDbContext context) : EFRepository<Message, ServerDbContext>(context), IMessageRepository;