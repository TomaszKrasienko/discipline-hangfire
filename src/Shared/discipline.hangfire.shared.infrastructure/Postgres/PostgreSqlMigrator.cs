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
						  activity_rule_id VARCHAR(30) NOT NULL
						, user_id VARCHAR(30) NOT NULL
						, mode VARCHAR(30) NOT NULL
						, selected_days NUMERIC[]
						, updated_at TIMESTAMP not NULL
					);

					create schema tasks
                          
					create table tasks.""Planned""
					(
						  id varchar(30) not null
						, activity_rule_id VARCHAR(30) not null 
						, user_id VARCHAR(30) not null 
						, planned_for DATE not null
						, created BOOL not null
						, primary key (id)
						, unique (activity_rule_id, user_id, planned_for)
					)
				END IF;
			END $$;";
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;
}