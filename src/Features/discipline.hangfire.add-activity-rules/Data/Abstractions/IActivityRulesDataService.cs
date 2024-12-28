using discipline.hangfire.add_activity_rules.DTOs;
using discipline.hangfire.shared.abstractions.Identifiers;

namespace discipline.hangfire.add_activity_rules.Data.Abstractions;

public interface IActivityRulesDataService
{
    Task AddActivityRule(ActivityRuleDto activityRuleDto, UserId userId, DateTime updatedAt);
}