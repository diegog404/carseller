using carseller1.Data;
using carseller1.Models;

namespace carseller1.Services
{
    public class ClientService
    {
        private readonly carseller1Context _context;

        public ClientService(carseller1Context context)
        {
            _context = context;
        }

        public List<Client> FindAll()
        {
            return _context.Client.OrderBy(x => x.Name).ToList();
        }
    }
}
