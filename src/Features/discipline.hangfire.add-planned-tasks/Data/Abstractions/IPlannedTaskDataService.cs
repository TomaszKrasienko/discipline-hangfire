namespace discipline.hangfire.add_planned_tasks.Data.Abstractions;

internal interface IPlannedTaskDataService
{
    Task CreatePlannedTaskAsync(Ulid activityRuleId, Ulid userId, DateOnly plannedFor, CancellationToken cancellationToken);
}