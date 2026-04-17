using carseller.Data;
using carseller.Models;
using Microsoft.EntityFrameworkCore;

namespace carseller.Services
{
    public class ClientService
    {
        private readonly carsellerContext _context;

        public ClientService(carsellerContext context)
        {
            _context = context;
        }

        public async Task<List<Client>> FindAllAsync()
        {
            return await _context.Client.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
