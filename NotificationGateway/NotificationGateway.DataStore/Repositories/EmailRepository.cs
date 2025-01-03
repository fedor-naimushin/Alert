using NotificationGateway.Core.Models;
using Shared.Repositories;

namespace NotificationGateway.DataStore.Repositories;

public class EmailRepository(ServerDbContext context) : EFRepository<Email, ServerDbContext>(context), IEmailRepository;