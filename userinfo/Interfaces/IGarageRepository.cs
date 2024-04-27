
using userinfo.Models;

namespace userinfo.Interfaces
{
    public interface IGarageRepository
    {
        Task<IEnumerable<Garage>> GetAll();
        Task<IEnumerable<Garage>> GetByUserIdAsync(string userId); // New method
        Task<Garage> GetByIdAsync(int vehicleId);
        bool add(Garage garage);
        bool update(Garage garage);
        bool delete(Garage garage);
        bool Save();
        Task<Garage?> GetByIdAsyncNoTracking(int vehicleId);
    }
}
