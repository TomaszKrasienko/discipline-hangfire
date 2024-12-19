using discipline.hangfire.activity_rules.Clients.Configuration;
using discipline.hangfire.activity_rules.Events.External;
using Microsoft.Extensions.Configuration;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class ActivityRulesServicesConfiguration
{
    public static IServiceCollection AddActivityRules(this IServiceCollection services, IConfiguration configuration)
        => services
            .AddBrokerConsumer<ActivityRuleRegistered>()
            .AddActivityRuleClientService(configuration);
}