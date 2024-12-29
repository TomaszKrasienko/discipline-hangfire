using discipline.hangfire.add_activity_rules.Data;
using discipline.hangfire.add_activity_rules.Data.Abstractions;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

internal static class DataServicesConfigurationExtensions
{
    internal static IServiceCollection AddData(this IServiceCollection services)
        => services
            .AddScoped<IActivityRulesDataService, ActivityRulesDataService>();
}