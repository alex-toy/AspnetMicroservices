using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace Discount.API.Extensions
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