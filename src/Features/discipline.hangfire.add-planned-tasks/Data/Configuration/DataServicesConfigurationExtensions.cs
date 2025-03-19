using discipline.hangfire.add_planned_tasks.Data;
using discipline.hangfire.add_planned_tasks.Data.Abstractions;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

internal static class DataServicesConfigurationExtensions
{
    internal static IServiceCollection AddData(this IServiceCollection services)
        => services
            .AddTransient<IActivityRulesDataService, ActivityRulesDataService>()
            .AddTransient<IPlannedTaskDataService, PlannedTaskDataService>();
}