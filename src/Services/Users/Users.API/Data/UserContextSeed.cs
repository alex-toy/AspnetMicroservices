using MongoDB.Driver;
using Users.API.Entities;

namespace Users.API.Data
{
    public class UserContextSeed
    {
        public static void SeedData(IMongoCollection<User> userCollection)
        {
            bool existProduct = userCollection.Find(p => true).Any();
            if (!existProduct)
            {
                userCollection.InsertManyAsync(GetPreconfiguredUser());
            }
        }

        private static IEnumerable<User> GetPreconfiguredUser()
        {
            return new List<User>()
            {
                new User()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    FirstName = "Alex",
                    LastName = "reaktor",
                    Email = "alex@test.fr",
                },
                new User()
                {
                    Id = "602d2149e773f2a3990b47f9",
                    FirstName = "Shirley",
                    LastName = "Lozano",
                    Email = "shirley@test.fr",
                },
            };
        }
    }
}
