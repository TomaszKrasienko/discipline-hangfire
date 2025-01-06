using discipline.hangfire.create_activity_from_planned.Data.Configuration;
using discipline.hangfire.create_activity_from_planned.Handlers.Configuration;
using discipline.hangfire.create_activity_from_planned.Publishers.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace discipline.hangfire.create_activity_from_planned.Configuration;

public static class CreateActivityFromPlannedServiceConfigurationExtension
{
    public static IServiceCollection SetCreateActivityFromPlanned(this IServiceCollection services)
        => services
            .AddDataServices()
            .AddHandlers()
            .AddBroker();
}