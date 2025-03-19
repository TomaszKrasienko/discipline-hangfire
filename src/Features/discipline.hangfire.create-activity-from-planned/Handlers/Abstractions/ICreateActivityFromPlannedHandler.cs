namespace discipline.hangfire.create_activity_from_planned.Handlers.Abstractions;

public interface ICreateActivityFromPlannedHandler
{
    Task Handle(CancellationToken cancellationToken = default);
}