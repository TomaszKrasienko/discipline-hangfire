using discipline.hangfire.shared.abstractions.Events;
using discipline.hangfire.shared.abstractions.Identifiers;

namespace discipline.hangfire.add_activity_rules.Events.External;

internal sealed record ActivityRuleRegistered(ActivityRuleId ActivityRuleId,
    UserId UserId) : IEvent;