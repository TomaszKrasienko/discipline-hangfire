using discipline.hangfire.create_activity_from_planned.Data.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace discipline.hangfire.create_activity_from_planned.Data.Configuration;

internal static class DataServicesConfigurationExtensions
{
    internal static IServiceCollection AddDataServices(this IServiceCollection services)
        => services
            .AddScoped<IPlannedTaskDataService, PlannedTaskDataService>();
}