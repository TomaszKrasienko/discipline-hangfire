using discipline.hangfire.create_activity_from_planned.Handlers.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace discipline.hangfire.create_activity_from_planned.Handlers.Configuration;

internal static class HandlersServiceConfigurationExtensions
{
    internal static IServiceCollection AddHandlers(this IServiceCollection services)
        => services.AddScoped<ICreateActivityFromPlannedHandler, CreateActivityFromPlannedHandler>();
}