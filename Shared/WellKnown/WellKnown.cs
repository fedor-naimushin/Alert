using Microsoft.Extensions.Configuration;

namespace Shared.WellKnown;

public static class WellKnown
{
    private static IConfiguration? _configuration;
    public const string MessagesQueue = "MessageRequests";
    public const string EmailsQueue = "EmailRequests";

    public static string DbConnectionString { get; private set; } = string.Empty;
    public static string RabbitMqConnectionString { get; private set; } = string.Empty;

    public static void Initialize(IConfiguration configuration)
    {
        _configuration = configuration;
        DbConnectionString = _configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' is not configured.");
        RabbitMqConnectionString = _configuration.GetConnectionString("RabbitMQConnection") ?? throw new InvalidOperationException("Connection string 'RabbitMQConnection' is not configured.");
    }
}
