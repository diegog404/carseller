using carseller1.Data;
using carseller1.Models;
using carseller1.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace carseller1.Services
{
    public class CompanyService
    {
        private readonly carseller1Context _context;

        public CompanyService(carseller1Context context)
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
            catch(DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
