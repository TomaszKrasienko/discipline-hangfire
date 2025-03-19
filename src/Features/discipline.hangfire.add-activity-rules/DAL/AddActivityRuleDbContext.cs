using Microsoft.EntityFrameworkCore;

namespace discipline.hangfire.add_activity_rules.DAL;

internal sealed class AddActivityRuleDbContext(DbContextOptions<AddActivityRuleDbContext> contextOptions)
    : DbContext(contextOptions)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("activity-rules");
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}