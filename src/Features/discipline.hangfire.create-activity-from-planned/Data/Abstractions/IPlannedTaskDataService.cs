using discipline.hangfire.create_activity_from_planned.Data.Entities;

namespace discipline.hangfire.create_activity_from_planned.Data.Abstractions;

internal interface IPlannedTaskDataService
{
    Task<PlannedTaskEntity?> GetPlannedTaskAsync(DateOnly day, CancellationToken cancellationToken);
    Task MarkAsProcessingAsync(Ulid plannedTaskId, CancellationToken cancellationToken);
    Task MarkAsDoneAsync(Ulid plannedTaskId, CancellationToken cancellationToken);
}