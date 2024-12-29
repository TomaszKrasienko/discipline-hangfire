using discipline.hangfire.add_planned_tasks.Clients;
using discipline.hangfire.add_planned_tasks.Data.Abstractions;
using discipline.hangfire.add_planned_tasks.Handlers.Abstractions;
using discipline.hangfire.shared.abstractions.Auth;

namespace discipline.hangfire.add_planned_tasks.Handlers;

internal sealed class AddPlannedTasksHandler(
    ICentreActivityRuleClient centreActivityRuleClient,
    IActivityRulesDataService activityRulesDataService,
    IPlannedTaskDataService plannedTaskDataService) : IAddPlannedTasksHandler
{
    public async Task HandleAsync(CancellationToken cancellationToken = default)
    {
        var today = DateOnly.FromDateTime(DateTime.UtcNow);
        
        var activeModes = await centreActivityRuleClient.GetActiveModeAsync(today);
        if (activeModes is null)
        {
            return;
        }
        
        var activityRules = await activityRulesDataService
            .GetByModesAsync(activeModes.Modes, activeModes.Day, cancellationToken);

        var plannedFor = DateOnly.FromDateTime(DateTime.UtcNow);
        
        foreach (var activityRule in activityRules)
        {
            await plannedTaskDataService.CreatePlannedTaskAsync(activityRule.ActivityRuleId, activityRule.UserId,
                plannedFor.AddDays(1), cancellationToken);
        }
    }
}