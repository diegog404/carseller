using carseller.Data;
using carseller.Models;
using carseller.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace carseller.Services
{
    public class SaleService
    {
        private readonly carsellerContext _context;

        public SaleService(carsellerContext context)
        {
            _context = context;
        }

        public async Task<List<Sale>> FindAllAsync()
        {
            return await _context.Sale.Include(obj => obj.User).Include(obj => obj.User).OrderBy(x => x.Id).ToListAsync();
        }

        public async Task InsertAsync(Sale obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Sale> FindByIdAsync(int id)
        {
            return await _context.Sale.Include(obj => obj.User).Include(obj => obj.User).FirstOrDefaultAsync(obj => obj.Id == id);
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
