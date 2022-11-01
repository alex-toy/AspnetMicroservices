using Inventory.API.Entities;

namespace Inventory.API.Repositories
{
    public interface IInventoryRepository
    {
        Task<Warehouse> Get(string name);
        Task<Warehouse> Update(Warehouse warehouse);
        Task Delete(string name);
    }
}
