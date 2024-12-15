using discipline.hangfire.server.Hangfire;
using Hangfire;
using Hangfire.PostgreSql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDisciplineHangfire(builder.Configuration);

var app = builder.Build();
app.UseDisciplineHangfireServer();
app.UseHttpsRedirection();
await app.RunAsync();