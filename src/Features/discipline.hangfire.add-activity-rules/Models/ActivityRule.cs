namespace discipline.hangfire.add_activity_rules.Models;

public sealed class ActivityRule
{
    public string ActivityRuleId { get; }
    public string Mode { get; }
    public IReadOnlyCollection<int>? SelectedDays { get; }

    private ActivityRule(string activityRuleId, 
        string mode, 
        IReadOnlyCollection<int>? selectedDays)
    {
        ActivityRuleId = activityRuleId;
        Mode = mode;
        SelectedDays = selectedDays;
    }

    public static ActivityRule Create(string activityRuleId, string mode, IReadOnlyCollection<int>? selectedDays)
        => new ActivityRule(activityRuleId, mode, selectedDays);
}