using carseller1.Data;
using carseller1.Models;
using NuGet.Protocol.Plugins;

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
            return _context.Vehicle.OrderBy(x => x.Id).ToList();
        }

        public void Insert(Vehicle obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Vehicle FindById(int id)
        {
            return _context.Vehicle.FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Vehicle.Find(id);
            _context.Vehicle.Remove(obj);
            _context.SaveChanges();
        }
    }
}
