using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace discipline.hangfire.infrastructure.RedisBroker.Configuration;

internal static class RedisBrokerServicesConfigurationExtensions
{
    internal static IServiceCollection AddRedisBroker(this IServiceCollection services, IConfiguration configuration)
        => services
            .Configure<RedisBrokerOptions>(configuration.GetSection(nameof(RedisBrokerOptions)))
            .AddSingleton<IConnectionMultiplexer>(sp =>
            {
                var options = sp.GetRequiredService<IOptions<RedisBrokerOptions>>();
                var connectionString = options.Value.ConnectionString;

                return ConnectionMultiplexer.Connect(connectionString);
            });
}