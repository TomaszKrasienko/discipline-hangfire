using discipline.hangfire.shared.abstractions.Identifiers;

namespace discipline.hangfire.add_activity_rules.Models;

public sealed class ActivityRule
{
    public ActivityRuleId ActivityRuleId { get; }
    public UserId UserId { get; }
    public string Mode { get; }
    public IReadOnlyCollection<int>? SelectedDays { get; }

#pragma warning disable CS8618, CS9264
    public ActivityRule() {}
#pragma warning restore CS8618, CS9264
    
    private ActivityRule(ActivityRuleId activityRuleId, 
        UserId userId,
        string mode, 
        IReadOnlyCollection<int>? selectedDays)
    {
        ActivityRuleId = activityRuleId;
        UserId = userId;
        Mode = mode;
        SelectedDays = selectedDays;
    }

    public static ActivityRule Create(ActivityRuleId activityRuleId,
        UserId userId, 
        string mode,
        IReadOnlyCollection<int>? selectedDays) 
        => new(activityRuleId, userId, mode, selectedDays);
}