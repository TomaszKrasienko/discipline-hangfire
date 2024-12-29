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
        connection.Open();
        
        const string sql = """
                           INSERT INTO (id, activity_rule_id, user_id, planned_for, created)
                           VALUES (@Id, @ActivityRuleId, @UserId, @PlannedFor, false)
                           """;

        await connection.ExecuteAsync(sql, new
        {
            Id = Ulid.NewUlid(),
            ActivityRuleId = activityRuleId,
            UserId = userId,
            PlannedFor = plannedFor
        });
    }
}