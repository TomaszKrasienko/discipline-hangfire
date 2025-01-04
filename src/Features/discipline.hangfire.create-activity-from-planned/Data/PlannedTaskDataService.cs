using discipline.hangfire.create_activity_from_planned.Data.Abstractions;
using discipline.hangfire.create_activity_from_planned.Data.Entities;

namespace discipline.hangfire.create_activity_from_planned.Data;

internal sealed class PlannedTaskDataService : IPlannedTaskDataService
{
    public Task<IReadOnlyCollection<PlannedTaskEntity>> GetPlannedTaskAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}