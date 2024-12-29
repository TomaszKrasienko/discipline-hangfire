using discipline.hangfire.add_planned_tasks.Handlers.Configuration;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extensions method for setting services for 'add planned tasks' use case
/// </summary>
public static class AddPlannedTasksServicesConfigurationExtensions
{
    public static IServiceCollection SetAddPlannedTasks(this IServiceCollection services)
        => services
            .AddData()
            .AddHandlers();
}