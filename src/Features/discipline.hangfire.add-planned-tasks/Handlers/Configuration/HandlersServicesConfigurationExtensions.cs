using discipline.hangfire.add_planned_tasks.Handlers.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace discipline.hangfire.add_planned_tasks.Handlers.Configuration;

internal static class HandlersServicesConfigurationExtensions
{
    internal static IServiceCollection AddHandlers(this IServiceCollection services)
        => services
            .AddScoped<IAddPlannedTasksHandler, AddPlannedTasksHandler>();
}