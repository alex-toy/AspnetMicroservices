using MongoDB.Driver;
using Users.API.Entities;

namespace Users.API.Data
{
    public interface IUserContext
    {
        IMongoCollection<User> Users { get; }
    }
}
