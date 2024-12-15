namespace discipline.hangfire.server.Hangfire;

internal sealed record PostgresOptions
{
    public required string ConnectionString { get; init; }
}