using discipline.hangfire.activity_rules.DTOs;

namespace discipline.hangfire.activity_rules.Data.Abstractions;

public interface IActivityRulesDataService
{
    Task AddActivityRule(ActivityRuleDto activityRuleDto);
}