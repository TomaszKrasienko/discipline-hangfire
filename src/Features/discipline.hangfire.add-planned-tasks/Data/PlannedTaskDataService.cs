using Dapper;
using discipline.hangfire.add_planned_tasks.Data.Abstractions;
using discipline.hangfire.shared.abstractions.DataAccess;

namespace discipline.hangfire.add_planned_tasks.Data;

internal sealed class PlannedTaskDataService(
    IDbContext context) : IPlannedTaskDataService
{
    public async Task CreatePlannedTaskAsync(Ulid activityRuleId, Ulid userId, DateOnly plannedFor,
        CancellationToken cancellationToken)
    {
        using var connection = context.GetConnection();
        
        const string sql = """
                           INSERT INTO tasks."Planned"(id, activity_rule_id, user_id, planned_for)
                           VALUES (@Id, @ActivityRuleId, @UserId, @PlannedFor)
                           """;

        await connection.ExecuteAsync(sql, new
        {
            Id = Ulid.NewUlid().ToString(),
            ActivityRuleId = activityRuleId.ToString(),
            UserId = userId.ToString(),
            PlannedFor = plannedFor.ToDateTime(TimeOnly.MinValue)
        });
    }
}