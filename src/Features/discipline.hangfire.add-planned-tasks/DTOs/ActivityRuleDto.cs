namespace discipline.hangfire.add_planned_tasks.DTOs;

internal sealed record ActivityRuleDto
{
    public required string ActivityRuleId { get; init; }
    public required string UserId { get; init; }
    public required string Mode { get; init; }
    public Ulid ParsedActivityRuleId => Ulid.Parse(ActivityRuleId); 
    public Ulid ParsedUserId => Ulid.Parse(UserId);
    
}