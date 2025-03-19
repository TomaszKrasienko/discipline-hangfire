using discipline.hangfire.infrastructure.Configuration;
using discipline.hangfire.infrastructure.Configuration.Options;
using discipline.hangfire.infrastructure.Logging.Configuration.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace discipline.hangfire.infrastructure.Logging.Configuration;

internal static class LoggingServicesConfigurationExtensions
{
    internal static IServiceCollection AddLogging(this IServiceCollection services, IConfiguration configuration)
        => services
            .AddOptions(configuration)
            .AddDistributedTracing();

    private static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        => services
            .ValidateAndBind<JaegerOptions, JaegerOptionsValidator>(configuration);
    
    private static IServiceCollection AddDistributedTracing(this IServiceCollection services)
    {
        var appOptions = services.GetOptions<AppOptions>();
        var jaegerOptions = services.GetOptions<JaegerOptions>();
        
        services.AddOpenTelemetry()
            .ConfigureResource(resource
                => resource.AddService(appOptions.Name!))
            .WithTracing(tracing 
                => tracing
                    .AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation()
                    .AddOtlpExporter(options => options.Endpoint = new Uri(jaegerOptions.Endpoint!)));
        
        return services;
    }
}