using discipline.hangfire.add_planned_tasks.Handlers.Abstractions;
using discipline.hangfire.create_activity_from_planned.Configuration;
using discipline.hangfire.create_activity_from_planned.Handlers.Abstractions;
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
    .SetAddPlannedTasks(builder.Configuration)
    .SetCreateActivityFromPlanned();

var app = builder.Build();
app.UseDisciplineHangfireServer();
app.UseHttpsRedirection();

RecurringJob.AddOrUpdate<IAddPlannedTasksHandler>(
    "add-planned-tasks",
    job => job.HandleAsync(default), 
    Cron.Daily);

RecurringJob.AddOrUpdate<ICreateActivityFromPlannedHandler>(
    "create-from-planned",
    job => job.Handle(default),
    Cron.Daily);

await app.RunAsync();