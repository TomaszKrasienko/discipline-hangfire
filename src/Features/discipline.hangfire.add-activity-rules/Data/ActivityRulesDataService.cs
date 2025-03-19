using Dapper;
using discipline.hangfire.add_activity_rules.Data.Abstractions;
using discipline.hangfire.add_activity_rules.DTOs;
using discipline.hangfire.shared.abstractions.DataAccess;
using discipline.hangfire.shared.abstractions.Identifiers;
using Microsoft.Extensions.Logging;

namespace discipline.hangfire.add_activity_rules.Data;

internal sealed class ActivityRulesDataService(
    ILogger<ActivityRulesDataService> logger,
    IDbContext context) : IActivityRulesDataService
{
    public async Task AddActivityRule(ActivityRuleDto activityRuleDto, UserId userId, DateTime updatedAt)
    {
        try
        {
            using var connection = context.GetConnection();

            const string sql = """
                               INSERT INTO centre."ActivityRules" ("activity_rule_id", "user_id", "mode", "selected_days", "updated_at")
                               VALUES (@ActivityRuleId, @UserId, @Mode, @SelectedDays, @UpdatedAt);
                               """;

            await connection.ExecuteAsync(sql, new
            {
                ActivityRuleId = activityRuleDto.ActivityRuleId.Value.ToString(),
                UserId = userId.Value.ToString(),
                Mode = activityRuleDto.Mode,
                SelectedDays = activityRuleDto.SelectedDays?.ToArray(),
                UpdatedAt = updatedAt
            });
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            throw;
        }
    }
}