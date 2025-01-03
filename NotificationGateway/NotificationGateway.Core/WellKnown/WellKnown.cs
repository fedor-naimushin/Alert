namespace NotificationGateway.Core.WellKnown;

public static class WellKnown
{
    public static readonly string? DbConnectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
    public static readonly string? RabbitMqConnectionString = Environment.GetEnvironmentVariable("RABBITMQ_CONNECTION_STRING");

    public const string MessagesQueue = "MessageRequests";
    public const string EmailsQueue = "EmailRequests";
}