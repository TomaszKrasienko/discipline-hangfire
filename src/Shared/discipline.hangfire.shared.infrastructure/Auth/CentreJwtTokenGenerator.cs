using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using discipline.hangfire.infrastructure.Auth.Configuration;
using discipline.hangfire.shared.abstractions.Auth;
using discipline.hangfire.shared.abstractions.Time;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace discipline.hangfire.infrastructure.Auth;

internal sealed class CentreJwtTokenGenerator(
    IOptions<JwtAuthOptions> jwtOptions,
    IClock clock) : ICentreTokenGenerator
{
    private readonly JwtSecurityTokenHandler _tokenHandler = new ();
    private readonly string _privateKeyPath = jwtOptions.Value.PrivateKeyCertPath;
    private readonly string _pasword = jwtOptions.Value.PrivateKeyPassword;
    private readonly TimeSpan _expiry = jwtOptions.Value.TokenExpiry;
    private readonly string _audience = jwtOptions.Value.Audience;
    private readonly string _issuer = jwtOptions.Value.Issuer;
    
    public string Get()
    {
        RSA privateKey = RSA.Create();
        privateKey.ImportFromEncryptedPem(input: File.ReadAllText(_privateKeyPath), password: _pasword);
        var key = new RsaSecurityKey(privateKey);
        
        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.RsaSha256);

        var now = clock.Now();
        var expirationTime = now.Add(_expiry);
        var jwt = new JwtSecurityToken(
            issuer: _issuer,
            audience: _audience,
            notBefore: now,
            expires: expirationTime,
            signingCredentials: signingCredentials);
        
        return _tokenHandler.WriteToken(jwt);
    }
}