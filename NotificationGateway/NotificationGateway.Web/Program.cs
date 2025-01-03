using NotificationGateway.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterCQS();
builder.Services.RegisterDbContext();
builder.Services.ResisterRabbitMq();
builder.Services.RegisterRepositories();
builder.Services.ResisterServices();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();

app.Services.RegisterMigrations();

app.Run();