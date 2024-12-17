using discipline.hangfire.infrastructure.Configuration;
using discipline.hangfire.server.Hangfire;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var allAssemblies = AppDomain
    .CurrentDomain
    .GetAssemblies()
    .ToList();

builder.Services
    .AddDisciplineHangfire(builder.Configuration)
    .AddInfrastructure(builder.Configuration, allAssemblies);

var app = builder.Build();
app.UseDisciplineHangfireServer();
app.UseHttpsRedirection();
await app.RunAsync();