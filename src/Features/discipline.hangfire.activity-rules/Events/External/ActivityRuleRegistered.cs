using discipline.hangfire.shared.Identifiers;

namespace discipline.hangfire.activity_rules.Events.External;

internal sealed record ActivityRuleRegistered(ActivityRuleId ActivityRuleId,
    UserId UserId);