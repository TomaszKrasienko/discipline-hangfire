using Dapper;
using discipline.hangfire.add_planned_tasks.Data.Abstractions;
using discipline.hangfire.add_planned_tasks.DTOs;
using discipline.hangfire.shared.abstractions.DataAccess;

namespace discipline.hangfire.add_planned_tasks.Data;

internal sealed class ActivityRulesDataService(
    IDbContext context) : IActivityRulesDataService
{
    public async Task<IReadOnlyCollection<ActivityRuleDto>> GetByModesAsync(List<string> modes, int day, CancellationToken cancellationToken = default)
    {
        using var connection = context.GetConnection();
        connection.Open();
        
        const string sql = """
                           SELECT 
                                  ar."activity_rule_id" AS "ActivityRuleId"
                                , ar."user_id" AS "UserId"
                                , ar."mode" AS "Mode" 
                                , ar."selected_days" AS "SelectedDays"
                                , ar."updated_at" AS "UpdatedAt"
                           FROM centre."ActivityRules" ar 
                           WHERE (ar."mode" = 'Custom' AND @day = ANY (ar.selected_days))
                              OR ar."mode" IN (@modes);
                           """;

        var result = await connection.QueryAsync<ActivityRuleDto>(sql, new
        {
            @day = day,
            @modes = modes
        });
        
        return result.ToList();
    }
}