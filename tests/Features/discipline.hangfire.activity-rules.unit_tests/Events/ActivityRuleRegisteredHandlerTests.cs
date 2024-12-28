using discipline.hangfire.add_activity_rules.Clients;
using discipline.hangfire.add_activity_rules.Data.Abstractions;
using discipline.hangfire.add_activity_rules.DTOs;
using discipline.hangfire.add_activity_rules.Events.External;
using discipline.hangfire.shared.abstractions.Auth;
using discipline.hangfire.shared.abstractions.Events;
using discipline.hangfire.shared.abstractions.Identifiers;
using discipline.hangfire.shared.abstractions.Time;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace discipline.hangfire.activity_rules.unit_tests.Events;

public sealed class ActivityRuleRegisteredHandlerTests
{
    [Fact]
    public async Task HandleAsync_GivenExistingActivityRuleId_ShouldAddByService()
    {
        //arrange
        var @event = new ActivityRuleRegistered(ActivityRuleId.New(), UserId.New());

        var activityRuleDto = new ActivityRuleDto
        {
            ActivityRuleId = @event.ActivityRuleId,
            Mode = "everyday",
            SelectedDays = null
        };
        
        _centreActivityRuleClient
            .GetActivityRules(@event.ActivityRuleId.Value, @event.UserId.Value)
            .Returns(activityRuleDto);
        
        var now = DateTime.UtcNow;
        _clock
            .Now()
            .Returns(now);
        
        //act
        await _handler.HandleAsync(@event, default);
        
        //assert
        await _activityRulesDataService
            .Received(1)
            .AddActivityRule(activityRuleDto, @event.UserId, now);
    }
    
    [Fact]
    public async Task HandleAsync_GivenNotExistedActivityRuleId_ShouldNotAddByService()
    {
        //arrange
        var @event = new ActivityRuleRegistered(ActivityRuleId.New(), UserId.New());

        _centreActivityRuleClient
            .GetActivityRules(@event.ActivityRuleId.Value, @event.UserId.Value)
            .ReturnsNull();
        
        //act
        await _handler.HandleAsync(@event, default);
        
        //assert
        await _activityRulesDataService
            .Received(0)
            .AddActivityRule(Arg.Any<ActivityRuleDto>(), Arg.Any<UserId>(),Arg.Any<DateTime>());
    }
    
    #region arrange
    private readonly ILogger<ActivityRuleRegisteredHandler> _logger;
    private readonly ICentreActivityRuleClient _centreActivityRuleClient;
    private readonly IActivityRulesDataService _activityRulesDataService;
    private readonly IClock _clock;
    private readonly IEventHandler<ActivityRuleRegistered> _handler;

    public ActivityRuleRegisteredHandlerTests()
    {
        _logger = Substitute.For<ILogger<ActivityRuleRegisteredHandler>>();
        _centreActivityRuleClient = Substitute.For<ICentreActivityRuleClient>();
        _activityRulesDataService = Substitute.For<IActivityRulesDataService>();
        _clock = Substitute.For<IClock>();
        _handler = new ActivityRuleRegisteredHandler(_logger, _centreActivityRuleClient,
            _activityRulesDataService, _clock);
    }
    #endregion
}