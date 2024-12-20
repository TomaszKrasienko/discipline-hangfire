using discipline.hangfire.activity_rules.Clients.Configuration;
using discipline.hangfire.activity_rules.Data;
using discipline.hangfire.activity_rules.Data.Abstractions;
using discipline.hangfire.activity_rules.Events.External;
using discipline.hangfire.infrastructure.RedisBroker;
using Microsoft.Extensions.Configuration;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class ActivityRulesServicesConfiguration
{
    public static IServiceCollection AddActivityRules(this IServiceCollection services, IConfiguration configuration)
        => services
            .AddActivityRuleClientService(configuration)
            .AddScoped<IActivityRulesDataService, ActivityRulesDataService>()
            .AddBrokerConsumer<ActivityRuleRegistered>();
}