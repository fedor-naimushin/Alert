using NotificationGateway.Core;
using NotificationGateway.DataStore.Repositories.Infrastructure;

namespace NotificationGateway.DataStore.Repositories.Realizations;

public class EmailRepository(ServerDbContext context) : EFRepository<Email, ServerDbContext>(context), IEmailRepository;