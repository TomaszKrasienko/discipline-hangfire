using discipline.hangfire.activity_rules.Clients;
using discipline.hangfire.activity_rules.Data.Abstractions;
using discipline.hangfire.shared.abstractions.Auth;

namespace discipline.hangfire.activity_rules.Events.External;

internal sealed class ActivityRuleRegisteredHandler(
    ICentreTokenGenerator centreTokenGenerator,
    ICentreActivityRuleClient client,
    IActivityRulesDataService dataService)
{
    public async Task HandleAsync(ActivityRuleRegistered @event, CancellationToken cancellationToken)
    {
        var token = centreTokenGenerator.Get();
        var activityRule = await client.GetActivityRules(token, @event.ActivityRuleId.Value,
            @event.UserId.Value);

        await dataService.AddActivityRule(activityRule);
    }
}