using discipline.hangfire.activity_rules.Events.External;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class ActivityRulesServicesConfiguration
{
    public static IServiceCollection AddActivityRules(this IServiceCollection services)
        => services
            .AddBrokerConsumer<ActivityRuleRegistered>();
}