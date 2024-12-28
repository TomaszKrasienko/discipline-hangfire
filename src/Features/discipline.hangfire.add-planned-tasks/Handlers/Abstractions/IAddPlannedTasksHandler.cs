namespace discipline.hangfire.add_planned_tasks.Handlers.Abstractions;

public interface IAddPlannedTasksHandler
{
    Task HandleAsync(CancellationToken cancellationToken = default);
}