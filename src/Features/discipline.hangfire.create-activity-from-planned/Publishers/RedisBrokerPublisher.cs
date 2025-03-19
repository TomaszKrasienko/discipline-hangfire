using discipline.hangfire.create_activity_from_planned.Publishers.Abstractions;
using discipline.hangfire.shared.abstractions.Brokers;
using discipline.hangfire.shared.abstractions.Serializer;
using Microsoft.Extensions.Logging;

namespace discipline.hangfire.create_activity_from_planned.Publishers;

internal sealed class RedisBrokerPublisher(
    ILogger<RedisBrokerPublisher> logger,
    ISerializer serializer,
    IRedisClient redisClient) : IBrokerPublisher
{
    public async Task SendAsync<T>(T message, CancellationToken cancellationToken) where T : class
    {
        logger.LogDebug("Sending message to redis broker");
        var json = serializer.ToJson(message);
        
        await redisClient.SendAsync(json, message.GetType().Name, cancellationToken);
    }
}