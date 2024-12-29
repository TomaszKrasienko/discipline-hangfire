namespace discipline.hangfire.add_planned_tasks.Data.Abstractions;

internal interface IPlannedTaskDataService
{
    Task CreatePlannedTask(Ulid activityRuleId, Ulid userId, DateOnly plannedFor, CancellationToken cancellationToken);
}