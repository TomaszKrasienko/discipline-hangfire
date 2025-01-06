using discipline.hangfire.shared.abstractions.Identifiers;

namespace discipline.hangfire.create_activity_from_planned.Publishers.Commands;

public sealed record CreateActivityFromActivityRuleCommand(ActivityRuleId ActivityRuleId, UserId UserId);