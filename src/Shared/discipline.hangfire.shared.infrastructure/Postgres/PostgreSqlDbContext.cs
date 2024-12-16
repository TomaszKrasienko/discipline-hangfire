using System.Data;
using discipline.hangfire.shared.abstractions.Context;

namespace discipline.hangfire.infrastructure.Postgres;

internal sealed class PostgreSqlDbContext(
    ) : IDbContext
{
    public IDbConnection GetConnection()
    {
        throw new NotImplementedException();
    }
}