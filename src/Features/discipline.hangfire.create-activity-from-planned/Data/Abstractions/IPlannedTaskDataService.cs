using discipline.hangfire.create_activity_from_planned.Data.Entities;

namespace discipline.hangfire.create_activity_from_planned.Data.Abstractions;

internal interface IPlannedTaskDataService
{
    Task<IReadOnlyCollection<PlannedTaskEntity>> GetPlannedTaskAsync(CancellationToken cancellationToken);
}