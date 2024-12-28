using discipline.hangfire.add_planned_tasks.Handlers.Configuration;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class AddPlannedTasksServicesConfigurationExtensions
{
    public static IServiceCollection SetAddPlannedTasks(this IServiceCollection services)
        => services
            .AddHandlers();
}