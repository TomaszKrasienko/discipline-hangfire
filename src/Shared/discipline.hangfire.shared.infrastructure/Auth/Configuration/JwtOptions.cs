namespace discipline.hangfire.infrastructure.Auth.Configuration;

public sealed record JwtOptions
{
    public required string PrivateCertPath { get; init; }
    public required TimeSpan TokenExpiry { get; init; }
    public required string Issuer { get; init; } 
    public required string Audience { get; init; }
}