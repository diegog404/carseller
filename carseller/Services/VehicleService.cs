using carseller.Data;
using carseller.Models;
using Microsoft.EntityFrameworkCore;

namespace carseller.Services
{
    public class VehicleService
    {
        private readonly carsellerContext _context;

        public VehicleService(carsellerContext context)
        {
            _context = context;
        }

        public async Task<List<Vehicle>> FindAllAsync()
        {
            return await _context.Vehicle.OrderBy(x => x.Id).ToListAsync();
        }

        public async Task InsertAsync(Vehicle obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
    }
}
