using carseller1.Data;
using carseller1.Models;

namespace carseller1.Services
{
    public class VehicleService
    {
        private readonly carseller1Context _context;

        public VehicleService(carseller1Context context)
        {
            _context = context;
        }

        public List<Vehicle> FindAll()
        {
            return _context.Vehicle.ToList();
        }

        public void Insert(Vehicle obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
