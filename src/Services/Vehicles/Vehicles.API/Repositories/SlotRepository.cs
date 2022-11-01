using Dapper;
using Npgsql;
using Vehicles.API.Entities;

namespace Vehicles.API.Repositories
{
    public class SlotRepository : ISlotRepository
    {
        private readonly IConfiguration _configuration;

        public SlotRepository(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<bool> Create(TruckSlot truckSlot)
        {
            string connectionString = _configuration.GetValue<string>("PostgresSettings:ConnectionString");
            using var connection = new NpgsqlConnection(connectionString);

            var affected = await connection.ExecuteAsync(
                "INSERT INTO TruckSlot (TruckId, StartDate, EndDate) VALUES (@TruckId, @StartDate, @EndDate)",
                new { TruckId = truckSlot.TruckId, StartDate = truckSlot.StartDate, EndDate = truckSlot.EndDate }
            );

            if (affected == 0) return false;

            return true;
        }

        public async Task<bool> Delete(string truckId)
        {
            string connectionString = _configuration.GetValue<string>("PostgresSettings:ConnectionString");
            using var connection = new NpgsqlConnection(connectionString);

            var affected = await connection.ExecuteAsync(
                "DELETE FROM TruckSlot WHERE TruckId = @truckId",
                new { TruckId = truckId }
            );

            if (affected == 0) return false;

            return true;
        }

        public async Task<TruckSlot> Get(string truckId)
        {
            string connectionString = _configuration.GetValue<string>("PostgresSettings:ConnectionString");
            using var connection = new NpgsqlConnection(connectionString);

            var truckSlot = await connection.QueryFirstOrDefaultAsync<TruckSlot>(
                "SELECT * FROM TruckSlot WHERE TruckId = @truckId", 
                new { TruckId = truckId }
            );

            if (truckSlot == null)
                return new TruckSlot { TruckId = "", StartDate = DateTime.MaxValue, EndDate = DateTime.MinValue };

            return truckSlot;
        }

        public async Task<bool> Update(TruckSlot truckSlot)
        {
            string connectionString = _configuration.GetValue<string>("PostgresSettings:ConnectionString");
            using var connection = new NpgsqlConnection(connectionString);

            var affected = await connection.ExecuteAsync(
                "UPDATE TruckSlot SET StartDate=@StartDate, EndDate=@EndDate WHERE TruckId = @TruckId",
                new { StartDate = truckSlot.StartDate, EndDate = truckSlot.EndDate, TruckId = truckSlot.TruckId }
            );

            if (affected == 0) return false;

            return affected != 0;
        }
    }
}
