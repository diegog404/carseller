using carseller1.Data;
using carseller1.Models;
using carseller1.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;

namespace carseller1.Services
{
    public class SaleService
    {
        private readonly carseller1Context _context;

        public SaleService(carseller1Context context)
        {
            _context = context;
        }

        public async Task<List<Sale>> FindAllAsync()
        {
            return await _context.Sale.ToListAsync();
        }

        public async Task InsertAsync(Sale obj)
        {

            obj.Client = await _context.Client.FirstAsync();
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Sale> FindByIdAsync(int id)
        {
            return await _context.Sale.Include(obj => obj.User).Include(obj => obj.Client).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Sale.FindAsync(id);
            _context.Sale.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Sale obj)
        {
            bool hasAny = await _context.Sale.AnyAsync(x => x.Id == obj.Id);

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
