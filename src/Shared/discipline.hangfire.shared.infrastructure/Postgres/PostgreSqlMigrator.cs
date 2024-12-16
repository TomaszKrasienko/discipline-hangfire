using Microsoft.Extensions.Hosting;

namespace discipline.hangfire.infrastructure.Postgres;

internal sealed class PostgreSqlMigrator : IHostedService
{
    public Task StartAsync(CancellationToken cancellationToken)
    {
        string sql = @"
            do $$
			begin 
				IF NOT EXISTS (SELECT 1 FROM pg_catalog.pg_namespace WHERE nspname = 'centre') 
				THEN
					CREATE SCHEMA centre;
				
					CREATE TABLE centre.""ActivityRules"" (
						  activity_rule_id VARCHAR(20) NOT NULL
						, user_id VARCHAR(20) NOT NULL
						, mode VARCHAR(30) NOT NULL
						, selected_days VARCHAR(20)
						, updated_at TIMESTAMP
					);
				END IF;
			END $$;";
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;
}