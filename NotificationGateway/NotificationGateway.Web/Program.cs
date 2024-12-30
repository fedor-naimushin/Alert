using Microsoft.EntityFrameworkCore;
using NotificationGateway.Application.Extensions;
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
    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(ServerDbContext)));
});

builder.Services.AddSingleton(sp => new ConnectionFactory() 
{ 
    Uri = new Uri(builder.Configuration.GetConnectionString("RabbitMQ")!)
});

builder.Services.RegisterRepositories();
builder.Services.ResisterServices();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();

app.Run();