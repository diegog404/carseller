using carseller.Data;
using carseller.Models;
using carseller.Services.Exceptions;
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

        public async Task<Vehicle> FindByIdAsync(int id)
        {
            return await _context.Vehicle.Include(obj => obj.Company).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Vehicle.FindAsync(id);
            _context.Vehicle.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Vehicle obj)
        {
            bool hasAny = await _context.Vehicle.AnyAsync(x => x.Id == obj.Id);


            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }

            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
