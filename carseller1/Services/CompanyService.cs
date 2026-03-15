using carseller1.Data;
using carseller1.Models;
using carseller1.Services.Exceptions;

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
            return _context.Company.OrderBy(x => x.Name).ToList();
        }

        public void Insert(Company obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Company FindById(int id)
        {
            return _context.Company.FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Company.Find(id);
            _context.Company.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Company obj)
        {
            if(!_context.Company.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not found");
            }

            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch(DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
