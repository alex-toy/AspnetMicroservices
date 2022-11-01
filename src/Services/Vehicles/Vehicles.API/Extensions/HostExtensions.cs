using Npgsql;

namespace Discount.API.Extensions
{
    public static class HostExtensions
    {
        public static IHost MigrateDatabase<TContext>(this IHost host, int? retry = 0)
        {
            int retryForAvailability = retry.Value;

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var configuration = services.GetRequiredService<IConfiguration>();
                var logger = services.GetRequiredService<ILogger<TContext>>();

                try
                {
                    logger.LogInformation("Migrating postresql database.");

                    using var connection = new NpgsqlConnection
                        (configuration.GetValue<string>("PostgresSettings:ConnectionString"));
                    connection.Open();

                    using var command = new NpgsqlCommand
                    {
                        Connection = connection
                    };

                    string[] queries = new string[] {

                        "DROP TABLE IF EXISTS TruckSlot",

                        @"CREATE TABLE TruckSlot (
	                        Id 				SERIAL PRIMARY KEY NOT NULL,
	                        TruckId     	VARCHAR(24) NOT NULL,
	                        StartDate    	Date,
	                        EndDate       	Date
                        );",

                        "INSERT INTO TruckSlot (TruckId, StartDate, EndDate) VALUES ('001', '2022-6-1', '2022-6-3');",
                        "INSERT INTO TruckSlot (TruckId, StartDate, EndDate) VALUES ('002', '2022-6-2', '2022-6-3');",
                        "INSERT INTO TruckSlot (TruckId, StartDate, EndDate) VALUES ('003', '2022-6-3', '2022-6-4');"
                    };

                    foreach (string query in queries)
                    {
                        command.ExecuteNonQueryMode(query);
                    }

                    logger.LogInformation("Migrated postresql database.");
                }
                catch (NpgsqlException ex)
                {
                    logger.LogError(ex, "An error occurred while migrating the postresql database");

                    if (retryForAvailability < 50)
                    {
                        retryForAvailability++;
                        System.Threading.Thread.Sleep(2000);
                        MigrateDatabase<TContext>(host, retryForAvailability);
                    }
                }
            }

            return host;
        }
    }
}