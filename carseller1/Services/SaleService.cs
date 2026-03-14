using carseller1.Data;
using carseller1.Models;
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

        public List<Sale> FindAll()
        {
            return _context.Sale.ToList();
        }

        public void Insert(Sale obj)
        {

            obj.Client = _context.Client.First();
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Sale FindById(int id)
        {
            return _context.Sale.FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Sale.Find(id);
            _context.Sale.Remove(obj);
            _context.SaveChanges();
        }
    }
}
