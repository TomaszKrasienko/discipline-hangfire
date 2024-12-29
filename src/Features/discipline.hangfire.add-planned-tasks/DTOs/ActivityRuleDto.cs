namespace discipline.hangfire.add_planned_tasks.DTOs;

internal sealed record ActivityRuleDto
{
    public Ulid ActivityRuleId { get; init; }
    public Ulid UserId { get; init; }
    public required string Mode { get; init; }
    public int[]? SelectedDays { get; init; }
    public DateTimeOffset UpdatedAt { get; init; }
}