using NotificationGateway.Core;
using NotificationGateway.Core.Models;
using NotificationGateway.DataStore.Repositories.Infrastructure;
using Shared.Repositories;

namespace NotificationGateway.DataStore.Repositories.Realizations;

public class EmailRepository(ServerDbContext context) : EFRepository<Email, ServerDbContext>(context), IEmailRepository;