using Microsoft.EntityFrameworkCore;
using userinfo.Interfaces;
using userinfo.Models;

namespace userinfo.Repository
{
    public class GarageRepository : IGarageRepository
    {
        private readonly AppDbContext _context;
        public GarageRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool add(Garage garage)
        {
            _context.Add(garage);
            return Save();
        }

        public bool delete(Garage garage)
        {
            _context.Remove(garage);
            return Save();
        }

        public async Task<IEnumerable<Garage>> GetAll()
        {
            return await _context.Garages.ToListAsync();
        }

        public async Task<Garage> GetByIdAsync(int id)
        {
            return await _context.Garages.FirstOrDefaultAsync(i => i.vehicleId == id);
        }

        public async Task<Garage> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Garages.AsNoTracking().FirstOrDefaultAsync(i => i.vehicleId == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool update(Garage garage)
        {
            _context.Update(garage);
            return Save();
        }
    }
}
       