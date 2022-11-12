using Npgsql;

namespace Bikes.API.Extensions
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

                        "DROP TABLE IF EXISTS Bike",

                        @"CREATE TABLE Bike (
	                        Id 				    SERIAL PRIMARY KEY NOT NULL,
	                        BikeId              VARCHAR(24) NOT NULL,
	                        CurrentLocation     VARCHAR(24) NOT NULL,
	                        Destination         VARCHAR(24) NULL,
	                        Capacity            INT NOT NULL
                        );",

                        "INSERT INTO Bike (BikeId, CurrentLocation, Destination, Capacity) VALUES ('001', 'Lyon', '', 5);",
                        "INSERT INTO Bike (BikeId, CurrentLocation, Destination, Capacity) VALUES ('002', 'Paris', '', 4);",
                        "INSERT INTO Bike (BikeId, CurrentLocation, Destination, Capacity) VALUES ('003', 'Marseille', '', 9);",
                        "INSERT INTO Bike (BikeId, CurrentLocation, Destination, Capacity) VALUES ('004', 'Lille', '', 1);",
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
