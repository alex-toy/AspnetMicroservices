using Bikes.Grpc.Entities;
using Dapper;
using Npgsql;

namespace Bikes.Grpc.Repositories
{
    public class BikeRepository : IBikeRepository
    {
        private readonly IConfiguration _configuration;

        public BikeRepository(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<bool> Create(Bike bike)
        {
            string connectionString = _configuration.GetValue<string>("PostgresSettings:ConnectionString");
            using var connection = new NpgsqlConnection(connectionString);

            var affected = await connection.ExecuteAsync(
                "INSERT INTO Bike (BikeId, CurrentLocation, Destination, Capacity) " +
                "VALUES (@BikeId, @CurrentLocation, @Destination, @Capacity)",
                new
                {
                    BikeId = bike.BikeId,
                    CurrentLocation = bike.CurrentLocation,
                    Destination = bike.Destination,
                    Capacity = bike.Capacity
                }
            );

            if (affected == 0) return false;

            return true;
        }

        public async Task<bool> Delete(string bikeId)
        {
            string connectionString = _configuration.GetValue<string>("PostgresSettings:ConnectionString");
            using var connection = new NpgsqlConnection(connectionString);

            var affected = await connection.ExecuteAsync(
                "DELETE FROM Bik WHERE BikeId = @BikeId",
                new { BikeId = bikeId }
            );

            if (affected == 0) return false;

            return true;
        }

        public async Task<Bike> Get(string bikeId)
        {
            string connectionString = _configuration.GetValue<string>("PostgresSettings:ConnectionString");
            using var connection = new NpgsqlConnection(connectionString);

            Bike? bike = await connection.QueryFirstOrDefaultAsync<Bike>(
                "SELECT * FROM Bike WHERE BikeId = @BikeId",
                new { BikeId = bikeId }
            );

            if (bike == null) return new Bike
            {
                BikeId = "",
                CurrentLocation = "",
                Destination = "",
                Capacity = 0
            };

            return bike;
        }

        public async Task<bool> Update(Bike bike)
        {
            string connectionString = _configuration.GetValue<string>("PostgresSettings:ConnectionString");
            using var connection = new NpgsqlConnection(connectionString);

            int numberRowsAffected = await connection.ExecuteAsync(
                "UPDATE Bike " +
                "SET CurrentLocation=@CurrentLocation, Destination=@Destination, Capacity=@Capacity " +
                "WHERE BikeId = @BikeId",
                new
                {
                    BikeId = bike.BikeId,
                    CurrentLocation = bike.CurrentLocation,
                    Destination = bike.Destination,
                    Capacity = bike.Capacity
                }
            );

            if (numberRowsAffected == 0) return false;

            return numberRowsAffected != 0;
        }
    }
}
