using discipline.hangfire.infrastructure.Configuration;
using discipline.hangfire.server.Hangfire;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddDisciplineHangfire(builder.Configuration)
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();
app.UseDisciplineHangfireServer();
app.UseHttpsRedirection();
await app.RunAsync();