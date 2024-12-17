using discipline.hangfire.shared.abstractions.Events;
using discipline.hangfire.shared.abstractions.Identifiers;

namespace discipline.hangfire.activity_rules.Events.External;

internal sealed record ActivityRuleRegistered(ActivityRuleId ActivityRuleId,
    UserId UserId) : IEvent;