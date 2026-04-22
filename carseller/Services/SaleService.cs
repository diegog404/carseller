using carseller.Data;
using carseller.Models;
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
            return await _context.Sale.OrderBy(x => x.Id).ToListAsync();
        }

        public async Task InsertAsync(Sale obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
    }
}
