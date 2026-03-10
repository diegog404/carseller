using carseller1.Data;
using carseller1.Models;

namespace carseller1.Services
{
    public class SaleService
    {
        private readonly carseller1Context _context;

        public SaleService(carseller1Context context)
        {
            _context = context;
        }

        public List<Sale> FindAll()
        {
            return _context.Sale.ToList();
        }

        public void Insert(Sale obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
