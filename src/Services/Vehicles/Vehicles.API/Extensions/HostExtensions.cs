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

                    using var connection = new NpgsqlConnection(configuration.GetValue<string>("PostgresSettings:ConnectionString"));
                    connection.Open();

                    using var command = new NpgsqlCommand
                    {
                        Connection = connection
                    };

                    string[] queries = new string[] {

                        "DROP TABLE IF EXISTS TruckSlot",

                        @"CREATE TABLE TruckSlot (
	                        Id 				    SERIAL PRIMARY KEY NOT NULL,
	                        TruckId     	    VARCHAR(24) NOT NULL,
	                        CurrentLocation     VARCHAR(24) NOT NULL,
	                        CurrentDestination  VARCHAR(24) NULL,
	                        Capacity            INT NOT NULL,
                        );",

                        "INSERT INTO TruckSlot (TruckId, CurrentLocation, CurrentDestination, Capacity) VALUES ('001', 'Lyon', '');",
                        "INSERT INTO TruckSlot (TruckId, CurrentLocation, CurrentDestination, Capacity) VALUES ('002', 'Paris', '');",
                        "INSERT INTO TruckSlot (TruckId, CurrentLocation, CurrentDestination, Capacity) VALUES ('003', 'Marseille', '');",
                        "INSERT INTO TruckSlot (TruckId, CurrentLocation, CurrentDestination, Capacity) VALUES ('004', 'Lille', '');",
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