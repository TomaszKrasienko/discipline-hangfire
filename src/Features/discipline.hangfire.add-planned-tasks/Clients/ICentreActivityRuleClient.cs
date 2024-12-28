using discipline.hangfire.add_planned_tasks.DTOs;
using Refit;

namespace discipline.hangfire.add_planned_tasks.Clients;

[Headers("Content-Type: application/json")]
internal interface ICentreActivityRuleClient
{
    [Get("/activity-rules-module/activity-rules-internal/{day}")]
    Task<ActiveModesDto?> GetActivityRules(DateOnly day); 
}