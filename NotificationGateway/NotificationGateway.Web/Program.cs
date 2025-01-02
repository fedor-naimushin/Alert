using Microsoft.EntityFrameworkCore;
using NotificationGateway.Application.Extensions;
using NotificationGateway.Core.WellKnown;
using NotificationGateway.DataStore;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
{
    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));
}

builder.Services.AddDbContext<ServerDbContext>(options =>
{
    options.UseNpgsql(WellKnown.DbConnectionString);
});

builder.Services.AddSingleton(sp => new ConnectionFactory
{ 
    Uri = new Uri(WellKnown.RabbitMqConnectionString!)
});

builder.Services.RegisterRepositories();
builder.Services.ResisterServices();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ServerDbContext>();
    dbContext.Database.Migrate();
}

app.Run();