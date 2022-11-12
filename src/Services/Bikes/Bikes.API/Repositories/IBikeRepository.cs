using Bikes.API.Entities;

namespace Bikes.API.Repositories
{
    public interface IBikeRepository
    {
        Task<Bike> Get(string currentLocation);
        Task<bool> Create(Bike bike);
        Task<bool> Update(Bike bike);
        Task<bool> Delete(string id);
    }
}
