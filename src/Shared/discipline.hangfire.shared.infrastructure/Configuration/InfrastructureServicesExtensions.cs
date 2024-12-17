using System.Reflection;
using discipline.hangfire.infrastructure.Postgres.Configuration;
using discipline.hangfire.infrastructure.Serializer.Configuration;
using discipline.hangfire.infrastructure.Time.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace discipline.hangfire.infrastructure.Configuration;

/// <summary>
/// Extensions to configure infrastructure-related services
/// for the application
/// </summary>
public static class InfrastructureServicesExtensions
{
    /// <summary>
    /// Configures infrastructure services required by the project
    /// </summary>
    /// <param name="services">The Dependency Injection (DI) container for registering services</param>
    /// <param name="configuration">Abstraction providing access to the application's configuration settings</param>
    /// <param name="assemblies">List of all assemblies</param>
    /// <returns>The updated DI services container as instance of <see cref="IServiceCollection"/></returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration,
        IEnumerable<Assembly> assemblies)
        => services
            .AddAuth(configuration)
            .AddClock()
            .AddPostgres(configuration)
            .AddEvents(assemblies)
            .AddSerializer();
}