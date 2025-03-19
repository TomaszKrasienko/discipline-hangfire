using discipline.hangfire.add_activity_rules.Clients.Configuration;
using discipline.hangfire.add_activity_rules.Events.External;
using Microsoft.Extensions.Configuration;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class AddActivityRulesServicesConfigurationExtensions
{
    public static IServiceCollection SetAddActivityRules(this IServiceCollection services, IConfiguration configuration)
        => services
            .AddActivityRuleClientService(configuration)
            .AddData()
            .AddBrokerConsumer<ActivityRuleRegistered>();
}