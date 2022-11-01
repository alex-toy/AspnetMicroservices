using Transport.API.Entities;

namespace Transport.API.Repositories
{
    public interface ITransportRepository
    {
        Task<TransportPlanning> Get(string userName);
        Task<TransportPlanning> Update(TransportPlanning transportPlanning);
        Task Delete(string userName);
    }
}
