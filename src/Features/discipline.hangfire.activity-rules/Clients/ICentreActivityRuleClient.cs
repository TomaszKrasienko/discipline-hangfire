using discipline.hangfire.activity_rules.DTOs;
using Refit;

namespace discipline.hangfire.activity_rules.Clients;

[Headers("Content-Type: application/json")]
internal interface ICentreActivityRuleClient
{
    [Get("/activity-rules-module/activity-rules-internal/{userId}/{activityRuleId}")]
    Task<ActivityRuleDto?> GetActivityRules([Header("Bearer_hf")] string token, Ulid activityRuleId, Ulid userId); 
}