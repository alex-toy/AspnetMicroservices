using MongoDB.Driver;
using Users.API.Data;
using Users.API.Entities;

namespace Users.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserContext _context;

        public UserRepository(IUserContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task Create(User user)
        {
            await _context.Users.InsertOneAsync(user);
        }

        public async Task<bool> Delete(string id)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _context.Users.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<User> Get(string id)
        {
            return await _context.Users.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.Find(p => true).ToListAsync();
        }

        public async Task<IEnumerable<User>> GetByEmail(string email)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq(p => p.Email, email);

            return await _context.Users.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<User>> GetByName(string name)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq(p => p.FirstName, name);

            return await _context.Users.Find(filter).ToListAsync();
        }

        public async Task<bool> Update(User user)
        {
            var updateResult = await _context.Users
                                        .ReplaceOneAsync(filter: g => g.Id == user.Id, replacement: user);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
