namespace discipline.hangfire.infrastructure.Auth.Configuration;

internal sealed record JwtAuthOptions
{
    public required string PrivateKeyCertPath { get; init; }
    public required string PrivateKeyPassword { get; init; }
    public required string PublicKeyCertPath { get; init; }
    public required TimeSpan TokenExpiry { get; init; }
    public required string Issuer { get; init; } 
    public required string Audience { get; init; }
}