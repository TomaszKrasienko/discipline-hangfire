using discipline.hangfire.add_planned_tasks.DTOs;

namespace discipline.hangfire.add_planned_tasks.Data.Abstractions;

internal interface IActivityRulesDataService
{
    Task<IReadOnlyCollection<ActivityRuleDto>> GetByModesAsync(List<string> modes, int day, CancellationToken cancellationToken = default);
}