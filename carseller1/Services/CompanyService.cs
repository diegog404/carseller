using carseller1.Data;
using carseller1.Models;

namespace carseller1.Services
{
    public class CompanyService
    {
        private readonly carseller1Context _context;

        public CompanyService(carseller1Context context)
        {
            _context = context;
        }

        public List<Company> FindAll()
        {
            return _context.Company.ToList();
        }

        public void Insert(Company obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
