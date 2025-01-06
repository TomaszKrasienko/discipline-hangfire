using Dapper;
using discipline.hangfire.add_planned_tasks.Data.Abstractions;
using discipline.hangfire.add_planned_tasks.DTOs;
using discipline.hangfire.shared.abstractions.DataAccess;
using Microsoft.Extensions.Logging;

namespace discipline.hangfire.add_planned_tasks.Data;

internal sealed class ActivityRulesDataService(
    ILogger<ActivityRulesDataService> logger,
    IDbContext context) : IActivityRulesDataService
{
    public async Task<IReadOnlyCollection<ActivityRuleDto>> GetByModesAsync(List<string> modes, int day, CancellationToken cancellationToken = default)
    {
        try
        {
            using var connection = context.GetConnection();

            const string sql = """
                               SELECT 
                                      ar."activity_rule_id" AS "ActivityRuleId"
                                    , ar."user_id" AS "UserId"
                                    , ar."mode" AS "Mode" 
                                    , ar."selected_days" AS "SelectedDays"
                                    , ar."updated_at" AS "UpdatedAt"
                               FROM centre."ActivityRules" ar 
                               WHERE (ar."mode" = 'Custom' AND @day = ANY (ar.selected_days))
                                  OR ar."mode" = ANY (@modes);
                               """;

            var result = await connection.QueryAsync<ActivityRuleDto>(sql, new
            {
                @day = day,
                @modes = modes
            });

            return result.ToList();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            throw;
        }
    }
}