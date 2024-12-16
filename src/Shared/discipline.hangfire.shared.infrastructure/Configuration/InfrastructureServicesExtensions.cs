using discipline.hangfire.infrastructure.Postgres.Configuration;
using discipline.hangfire.infrastructure.Time.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace discipline.hangfire.infrastructure.Configuration;

public static class InfrastructureServicesExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        => services
            .AddAuth(configuration)
            .AddClock()
            .AddPostgres(configuration);
}