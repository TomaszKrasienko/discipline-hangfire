using System.Data;

namespace discipline.hangfire.shared.abstractions.Context;

public interface IDbContext
{
    IDbConnection GetConnection();
}