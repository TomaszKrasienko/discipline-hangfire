using discipline.hangfire.shared.abstractions.DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace discipline.hangfire.infrastructure.Postgres.Configuration;

internal static class PostgreServicesConfigurationExtensions
{
    internal static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
        => services
            .AddOptions(configuration)
            .AddServices();
    
    private static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        => services
            .Configure<LogicPostgreOptions>(configuration.GetSection(nameof(LogicPostgreOptions)));

    private static IServiceCollection AddServices(this IServiceCollection services)
        => services.AddScoped<IDbContext, PostgreSqlDbContext>();
}