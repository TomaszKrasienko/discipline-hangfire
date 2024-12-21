using discipline.hangfire.shared.abstractions.Identifiers;

namespace discipline.hangfire.activity_rules.DTOs;

public sealed record ActivityRuleDto
{
    public required ActivityRuleId ActivityRuleId { get; init; }
    public required string Mode { get; init; }
    public IReadOnlyList<int>? SelectedDays { get; init; }
}