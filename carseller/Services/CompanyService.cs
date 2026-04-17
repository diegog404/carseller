using carseller.Data;
using carseller.Models;
using carseller.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace carseller.Services
{
    public class CompanyService
    {
        private readonly carsellerContext _context;

        public CompanyService(carsellerContext context)
        {
            _context = context;
        }

        public async Task<List<Company>> FindAllAsync()
        {
            return await _context.Company.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task InsertAsync(Company obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Company> FindByIdAsync(int id)
        {
            return await _context.Company.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Company.FindAsync(id);
            _context.Company.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Company obj)
        {
            bool hasAny = await _context.Company.AnyAsync(x => x.Id == obj.Id);

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
