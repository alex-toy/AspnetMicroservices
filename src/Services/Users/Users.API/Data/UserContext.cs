using MongoDB.Driver;
using Users.API.Entities;

namespace Users.API.Data
{
    public class UserContext : IUserContext
    {
        public UserContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("MongoSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("MongoSettings:DatabaseName"));

            Users = database.GetCollection<User>(configuration.GetValue<string>("MongoSettings:CollectionName"));
            UserContextSeed.SeedData(Users);
        }

        public IMongoCollection<User> Users { get; }
    }
}
