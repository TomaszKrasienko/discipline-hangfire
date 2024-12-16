namespace discipline.hangfire.infrastructure.Postgres.Configuration;

public sealed record LogicPostgreOptions
{
    public required string ConnectionString { get; init; }
}