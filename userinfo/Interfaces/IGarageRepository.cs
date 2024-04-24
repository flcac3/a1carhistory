
using userinfo.Models;

namespace userinfo.Interfaces
{
    public interface IGarageRepository
    {
        Task<IEnumerable<Garage>> GetAll();
        Task<Garage> GetByIdAsync(int vehicleId);
        bool add(Garage garage);
        bool update(Garage garage);
        bool delete(Garage garage);
        bool Save();
    }
}
