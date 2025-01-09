using MessageNotifier.Application.Extensions;
using MessageNotifier.Application.Models;
using Shared.WellKnown;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

WellKnown.Initialize(builder.Configuration);
builder.Services.Configure<Auth>(builder.Configuration.GetSection(nameof(Auth)));
builder.Services.RegisterRabbitMq();

var app = builder.Build();

app.UseAuthorization();
app.MapControllers();

app.Run();