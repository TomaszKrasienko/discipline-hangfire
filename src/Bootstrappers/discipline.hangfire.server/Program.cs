using discipline.hangfire.add_planned_tasks.Handlers.Abstractions;
using discipline.hangfire.infrastructure.Configuration;
using discipline.hangfire.server.Hangfire;
using Hangfire;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var allAssemblies = AppDomain
    .CurrentDomain
    .GetAssemblies()
    .ToList();

builder.Services
    .AddDisciplineHangfire(builder.Configuration)
    .AddInfrastructure(builder.Configuration, allAssemblies)
    .SetAddActivityRules(builder.Configuration)
    .SetAddPlannedTasks(builder.Configuration);

var app = builder.Build();
app.UseDisciplineHangfireServer();
app.UseHttpsRedirection();

RecurringJob.AddOrUpdate<IAddPlannedTasksHandler>(
    "add-planned-tasks",
    job => job.HandleAsync(default)
    , Cron.Daily);

await app.RunAsync();