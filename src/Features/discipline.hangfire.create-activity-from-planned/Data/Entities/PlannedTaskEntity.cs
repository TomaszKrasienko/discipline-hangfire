using discipline.hangfire.shared.abstractions.Identifiers;

namespace discipline.hangfire.create_activity_from_planned.Data.Entities;

/// <summary>
/// Represents planned task stored in database.
/// </summary>
internal sealed record PlannedTaskEntity
{
    /// <summary>
    /// Unique identifier of planned task.
    /// </summary>
    public Ulid Id { get; private init; }
    
    /// <summary>
    /// Identifier of activity rule based on which planned task was created.
    /// </summary>
    public ActivityRuleId ActivityRuleId { get; private init; }
    
    /// <summary>
    /// Identifier of the owner of 'ActivityRule'.
    /// </summary>
    public UserId UserId { get; init; }
    
    /// <summary>
    /// Date when task is scheduled to be created.
    /// </summary>
    public DateOnly PlannedFor { get; init; }
    
    /// <summary>
    /// Indicates whether the planned task has been created.
    /// <c>new</c> if the task was created;
    /// <c>processing</c> while working with task;
    /// <c>created</c> when finished use case
    /// </summary>
    public string State { get; init; }

    /// <summary>
    /// Creates a new instance <see cref="PlannedTaskEntity"/>. Maps field on target type.
    /// </summary>
    /// <exception cref="ArgumentException">Thrown if any if the input type is invalid</exception>
    public PlannedTaskEntity(string id, string activityRuleId, string userId, DateTime plannedFor, string state)
    {
        if (!Ulid.TryParse(id, out var convertedId))
        {
            throw new ArgumentException($"Parameter '{nameof(id)}' with Value: '{id}' cannot be converted to a Ulid");
        }
        
        Id = convertedId;
        ActivityRuleId = ActivityRuleId.Parse(activityRuleId);
        UserId = UserId.Parse(userId);
        PlannedFor = DateOnly.FromDateTime(plannedFor);
        State = state;
    }
}