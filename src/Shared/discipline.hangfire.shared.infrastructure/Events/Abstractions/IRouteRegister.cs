using discipline.hangfire.shared.abstractions.Events;

namespace discipline.hangfire.infrastructure.Events.Abstractions;

internal interface IRouteRegister
{
    string GetChannel<T>() where T : class, IEvent;
}