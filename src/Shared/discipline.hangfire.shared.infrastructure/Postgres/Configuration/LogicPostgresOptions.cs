namespace discipline.hangfire.infrastructure.Postgres.Configuration;

public sealed record LogicPostgresOptions
{
    public required string ConnectionString { get; init; }
}