using System.Net.Http.Json;
using discipline.hangfire.add_activity_rules.Clients;
using discipline.hangfire.add_activity_rules.DAL;
using discipline.hangfire.add_activity_rules.DTOs;
using discipline.hangfire.add_activity_rules.Models;
using discipline.hangfire.shared.abstractions.Events;
using discipline.hangfire.shared.abstractions.Identifiers;
using discipline.hangfire.shared.abstractions.Time;
using Microsoft.Extensions.Logging;

namespace discipline.hangfire.add_activity_rules.Events.External;

internal sealed class ActivityRuleRegisteredHandler(
    ILogger<ActivityRuleRegisteredHandler> logger,
    ICentreActivityRuleClient client,
    IClock clock,
    AddActivityRuleDbContext context) : IEventHandler<ActivityRuleRegistered>
{
    public async Task HandleAsync(ActivityRuleRegistered @event, CancellationToken cancellationToken)
    {
        var stronglyActivityRuleId = ActivityRuleId.Parse(@event.ActivityRuleId);
        var stronglyUserId = UserId.Parse(@event.UserId);
        
        var activityRuleResponse = await client.GetActivityRules(stronglyActivityRuleId.Value,
            stronglyUserId.Value);

        if (!activityRuleResponse.IsSuccessStatusCode)
        {
            logger.LogError("Activity Rule with 'Id': {0} and 'UserId': {1} not found", 
                stronglyActivityRuleId.Value, stronglyUserId.Value);
            return;
        }

        var activityRuleResult = await activityRuleResponse.Content.ReadFromJsonAsync<ActivityRuleDto>(cancellationToken);

        if (activityRuleResult is null)
        {
            logger.LogError("Activity Rule with 'Id': {0} and 'UserId': {1} not found", 
                stronglyActivityRuleId.Value, stronglyUserId.Value);
            return;
        }
        
        var activityRule = ActivityRule.Create(stronglyActivityRuleId, stronglyUserId, activityRuleResult.Mode,
            activityRuleResult.SelectedDays);
        
        context.Add(activityRule);
    }
}