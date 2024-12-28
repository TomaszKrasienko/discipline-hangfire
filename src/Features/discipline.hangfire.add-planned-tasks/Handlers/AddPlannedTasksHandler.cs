using discipline.hangfire.add_planned_tasks.Handlers.Abstractions;

namespace discipline.hangfire.add_planned_tasks.Handlers;

internal sealed class AddPlannedTasksHandler : IAddPlannedTasksHandler
{
    public Task HandleAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}