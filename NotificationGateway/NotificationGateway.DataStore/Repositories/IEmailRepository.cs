using NotificationGateway.Core.Models;
using Shared.Repositories.Infrastructure;

namespace NotificationGateway.DataStore.Repositories;

public interface IEmailRepository : IRepository<Email>
{
}