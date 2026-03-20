using carseller1.Data;
using carseller1.Models;
using carseller1.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;

namespace carseller1.Services
{
    public class UserService
    {
        private readonly carseller1Context _context;

        public UserService(carseller1Context context)
        {
            _context = context;
        }

        public async Task<List<User>> FindAllAsync()
        {
            return await _context.User.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task InsertAsync(User obj)
        {
            _context.Add(obj);
           await _context.SaveChangesAsync();
        }

        public async Task<User> FindByIdAsync(int id)
        {
            return await _context.User.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.User.FindAsync(id);
            _context.User.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User obj)
        {
            bool hasAny = await _context.User.AnyAsync(x => x.Id == obj.Id);

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
