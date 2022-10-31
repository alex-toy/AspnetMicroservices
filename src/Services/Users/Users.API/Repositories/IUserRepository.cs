using Users.API.Entities;

namespace Users.API.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();

        Task<User> Get(string id);

        Task<IEnumerable<User>> GetByName(string name);

        Task<IEnumerable<User>> GetByEmail(string email);

        Task Create(User user);

        Task<bool> Update(User user);

        Task<bool> Delete(string id);
    }
}
