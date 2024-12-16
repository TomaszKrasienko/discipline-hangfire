using discipline.hangfire.shared.abstractions.Events;
using Microsoft.Extensions.Hosting;
using StackExchange.Redis;

namespace discipline.hangfire.infrastructure.RedisBroker;

internal sealed class RedisConsumer<T>(
    IConnectionMultiplexer connectionMultiplexer,
    IRouteRegister routeRegister) : BackgroundService where T : class, IEvent  
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var subscriber = connectionMultiplexer.GetSubscriber();
        var channel = routeRegister.GetChannel<T>();

        await subscriber.SubscribeAsync(new RedisChannel(channel, RedisChannel.PatternMode.Auto), (channel, message) =>
        {
            
        });
    }
}

internal interface IRouteRegister
{
    string GetChannel<T>() where T : class, IEvent;
}