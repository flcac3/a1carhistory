using Microsoft.EntityFrameworkCore;
using userinfo.Interfaces;
using userinfo.Models;

namespace userinfo.Repository
{
    public class ServiceLogsRepository : IServiceLogsRepository
    {
        private readonly AppDbContext _context;
        public ServiceLogsRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool add(Servicelog servicelog)
        {
            _context.Add(servicelog);
            return Save();
        }

        public bool delete(Servicelog servicelog)
        {
            _context.Remove(servicelog);
            return Save();
        }

        public async Task<IEnumerable<Servicelog>> GetAll()
        {
            return await _context.Servicelogs.ToListAsync();
        }

        public async Task<IEnumerable<Servicelog>> GetByIdAsync(int id)
        {
            var garage = await _context.Servicelogs.FirstOrDefaultAsync(i => i.vehicleId == id);
            if (garage == null)
            {
                throw new Exception($"No service log found with id {id}");
            }
            return (IEnumerable<Servicelog>)garage;
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool update(Servicelog servicelog)
        {
            throw new NotImplementedException();
        }
    }
}
