using Npgsql;

namespace Bikes.API.Extensions
{
    public static class NpgsqlCommandExtension
    {
        public static void ExecuteNonQueryMode(this NpgsqlCommand command, string query)
        {
            command.CommandText = query;
            command.ExecuteNonQuery();
        }
    }
}
