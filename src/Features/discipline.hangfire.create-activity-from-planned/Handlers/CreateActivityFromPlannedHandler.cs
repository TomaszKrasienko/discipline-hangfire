using discipline.hangfire.create_activity_from_planned.Data.Abstractions;
using discipline.hangfire.create_activity_from_planned.Handlers.Abstractions;
using discipline.hangfire.create_activity_from_planned.Publishers.Abstractions;
using discipline.hangfire.create_activity_from_planned.Publishers.Commands;
using discipline.hangfire.shared.abstractions.DataAccess;
using discipline.hangfire.shared.abstractions.Time;
using Microsoft.Extensions.Logging;

namespace discipline.hangfire.create_activity_from_planned.Handlers;

internal sealed class CreateActivityFromPlannedHandler(
    IDbTransactionManager dbTransactionManager,
    IPlannedTaskDataService plannedTaskDataService,
    IClock clock,
    IBrokerPublisher brokerPublisher) : ICreateActivityFromPlannedHandler
{
    public async Task Handle(CancellationToken cancellationToken = default)
    {
        try
        {
            while (true)
            {
                using var dbTransaction = dbTransactionManager.Begin();
                var plannedTask = await plannedTaskDataService
                    .GetPlannedTaskAsync(DateOnly.FromDateTime(clock.Now()), cancellationToken);

                if (plannedTask is null)
                {
                    dbTransactionManager.Rollback();
                    return;
                }

                await plannedTaskDataService.MarkAsProcessingAsync(plannedTask.Id, cancellationToken);
                dbTransactionManager.Commit();

                dbTransactionManager.Begin();
                var command = new CreateActivityFromActivityRuleCommand(plannedTask.ActivityRuleId, plannedTask.UserId);
                await brokerPublisher.SendAsync(command, cancellationToken);

                await plannedTaskDataService.MarkAsDoneAsync(plannedTask.Id, cancellationToken);
                dbTransactionManager.Commit();
            }
        }
        catch (Exception ex)
        {
            dbTransactionManager.Rollback();
        }
    }
}