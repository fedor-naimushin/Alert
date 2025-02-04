using NotificationGateway.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterWellKnows(builder.Configuration);
builder.Services.RegisterCQS();
builder.Services.RegisterDbContext();
builder.Services.RegisterRabbitMq();
builder.Services.RegisterRepositories();
builder.Services.ResisterServices();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();

app.Run();