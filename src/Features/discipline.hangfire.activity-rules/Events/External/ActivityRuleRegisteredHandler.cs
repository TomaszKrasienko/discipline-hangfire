using discipline.hangfire.activity_rules.Clients;
using discipline.hangfire.activity_rules.Data;
using discipline.hangfire.activity_rules.Data.Abstractions;
using discipline.hangfire.shared.abstractions.Auth;
using discipline.hangfire.shared.abstractions.Events;
using discipline.hangfire.shared.abstractions.Time;
using Microsoft.Extensions.Logging;

namespace discipline.hangfire.activity_rules.Events.External;

internal sealed class ActivityRuleRegisteredHandler(
    ILogger<ActivityRuleRegisteredHandler> logger,
    ICentreActivityRuleClient client,
    IActivityRulesDataService dataService,
    IClock clock) : IEventHandler<ActivityRuleRegistered>
{
    public async Task HandleAsync(ActivityRuleRegistered @event, CancellationToken cancellationToken)
    {
        var activityRule = await client.GetActivityRules(@event.ActivityRuleId.Value,
            @event.UserId.Value);

        if (activityRule is null)
        {
            logger.LogError("Activity Rule with 'Id': {0} and 'UserId': {1} not found", @event.ActivityRuleId.Value, 
                @event.UserId.Value);
            return;
        }
        
        await dataService.AddActivityRule(activityRule, @event.UserId, clock.Now());
    }
}