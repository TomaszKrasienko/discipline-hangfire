using discipline.hangfire.add_activity_rules.DTOs;
using Refit;

namespace discipline.hangfire.add_activity_rules.Clients;

[Headers("Content-Type: application/json")]
internal interface ICentreActivityRuleClient
{
    [Get("/activity-rules-module/activity-rules-internal/{userId}/{activityRuleId}")]
    Task<ActivityRuleDto?> GetActivityRules(Ulid activityRuleId, Ulid userId); 
}