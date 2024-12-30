namespace discipline.hangfire.infrastructure.Configuration.Options;

internal sealed record AppOptions
{
    public string Name { get; init; } = string.Empty;
}