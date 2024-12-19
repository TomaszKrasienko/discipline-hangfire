using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace discipline.hangfire.activity_rules.Clients.Configuration;

internal static class ActivityRuleClientServiceConfiguration
{
    internal static IServiceCollection AddActivityRuleClientService(this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddRefitClient<ICentreActivityRuleClient>()
            .ConfigureHttpClient(x => x.BaseAddress = new Uri("http://localhost:5039"));
        return services;
    }
}