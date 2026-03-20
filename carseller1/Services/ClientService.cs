using carseller1.Data;
using carseller1.Models;
using Microsoft.EntityFrameworkCore;

namespace carseller1.Services
{
    public class ClientService
    {
        private readonly carseller1Context _context;

        public ClientService(carseller1Context context)
        {
            _context = context;
        }

        public async Task<List<Client>> FindAllAsync()
        {
            return await _context.Client.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<Client> FindByIdAsync(int id)
        {
            return await _context.Client.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Client.FindAsync(id);
            _context.Client.Remove(obj);
            await _context.SaveChangesAsync();
        }
    }
}
