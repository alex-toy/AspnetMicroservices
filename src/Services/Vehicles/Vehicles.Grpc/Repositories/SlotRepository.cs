﻿using Dapper;
using Npgsql;
using Vehicles.Grpc.Entities;

namespace Vehicles.Grpc.Repositories
{
    public class SlotRepository : ISlotRepository
    {
        private readonly IConfiguration _configuration;

        public SlotRepository(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<bool> CreateSlot(string currentLocation, string newDestination)
        {
            string connectionString = _configuration.GetValue<string>("PostgresSettings:ConnectionString");
            using var connection = new NpgsqlConnection(connectionString);

            var affected = await connection.ExecuteAsync(
                "UPDATE TruckSlot " +
                "SET CurrentDestination = @NewDestination " +
                "WHERE CurrentLocation = @CurrentLocation; ",
                new
                {
                    CurrentLocation = currentLocation,
                    NewDestination = newDestination,
                }
            );

            if (affected == 0) return false;

            return true;
        }

        public async Task<bool> Create(TruckSlot truckSlot)
        {
            string connectionString = _configuration.GetValue<string>("PostgresSettings:ConnectionString");
            using var connection = new NpgsqlConnection(connectionString);

            var affected = await connection.ExecuteAsync(
                "INSERT INTO TruckSlot (TruckId, CurrentLocation, CurrentDestination, Capacity) " +
                "VALUES (@TruckId, @StartDate, @EndDate)",
                new
                {
                    TruckId = truckSlot.TruckId,
                    CurrentLocation = truckSlot.CurrentLocation,
                    CurrentDestination = truckSlot.CurrentDestination,
                    Capacity = truckSlot.Capacity
                }
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

            if (truckSlot == null) return new TruckSlot
            {
                TruckId = "",
                CurrentLocation = "",
                CurrentDestination = "",
                Capacity = 0
            };

            return truckSlot;
        }

        public async Task<bool> Update(TruckSlot truckSlot)
        {
            string connectionString = _configuration.GetValue<string>("PostgresSettings:ConnectionString");
            using var connection = new NpgsqlConnection(connectionString);

            var affected = await connection.ExecuteAsync(
                "UPDATE TruckSlot SET CurrentLocation=@CurrentLocation, CurrentDestination=@CurrentDestination, Capacity=@Capacity " +
                "WHERE TruckId = @TruckId",
                new
                {
                    CurrentLocation = truckSlot.CurrentLocation,
                    CurrentDestination = truckSlot.CurrentDestination,
                    Capacity = truckSlot.Capacity,
                    TruckId = truckSlot.TruckId
                }
            );

            if (affected == 0) return false;

            return affected != 0;
        }
    }
}
