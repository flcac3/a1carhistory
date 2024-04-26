using userinfo.Models;

namespace userinfo.Interfaces
{
    public interface IServiceLogsRepository
    {
        Task<IEnumerable<Servicelog>> GetAll();
        Task<Servicelog> GetByIdAsync(int servicelogId);
        bool add(Servicelog garage);
        bool update(Servicelog garage);
        bool delete(Servicelog garage);
        bool Save();
    }
}
