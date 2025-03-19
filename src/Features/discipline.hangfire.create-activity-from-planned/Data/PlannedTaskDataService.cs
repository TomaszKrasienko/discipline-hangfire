using Dapper;
using discipline.hangfire.create_activity_from_planned.Data.Abstractions;
using discipline.hangfire.create_activity_from_planned.Data.Entities;
using discipline.hangfire.shared.abstractions.DataAccess;

namespace discipline.hangfire.create_activity_from_planned.Data;

internal sealed class PlannedTaskDataService(
    IDbTransactionManager dbTransactionManager) : IPlannedTaskDataService
{
    public async Task<PlannedTaskEntity?> GetPlannedTaskAsync(DateOnly day, CancellationToken cancellationToken)
    {
        try
        {
            var connection = dbTransactionManager.Connection;

            var sql = """
                      SELECT
                             p."id" AS "Id"
                           , p."activity_rule_id" AS "ActivityRuleId"
                           , p."user_id" AS "UserId"
                           , p."planned_for" AS "PlannedFor"
                           , p."state" AS "State"
                      FROM tasks."Planned" p 
                      WHERE p."planned_for" = @day
                        AND p."state" = @state
                      ORDER BY p."id"
                      LIMIT 1
                      FOR UPDATE;
                      """;

            var plannedTask = await connection.QueryFirstOrDefaultAsync<PlannedTaskEntity>(sql, new
            {
                @state = "new",
                @day = day.ToDateTime(TimeOnly.MinValue)
            });

            return plannedTask;
        }
        catch (Exception ex)
        {
            dbTransactionManager.Rollback();
            throw;
        }
    }

    public async Task MarkAsProcessingAsync(Ulid plannedTaskId, CancellationToken cancellationToken)
    {
        try
        {
            var connection = dbTransactionManager.Connection;
            var sql = """
                      UPDATE tasks."Planned"
                      SET state = 'processing'
                      WHERE id = @plannedTaskId
                      """;

            await connection.ExecuteAsync(sql, new
            {
                @plannedTaskId = plannedTaskId.ToString()
            });
            
        }
        catch (Exception ex)
        {
            dbTransactionManager.Rollback();
            throw;
        }
    }

    public async Task MarkAsDoneAsync(Ulid plannedTaskId, CancellationToken cancellationToken)
    {
        try
        {
            var connection = dbTransactionManager.Connection;
            var sql = """
                      UPDATE tasks."Planned"
                      SET state = 'done'
                      WHERE id = @plannedTaskId
                      """;

            await connection.ExecuteAsync(sql, new
            {
                @plannedTaskId = plannedTaskId.ToString()
            });
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}