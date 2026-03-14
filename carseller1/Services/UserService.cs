using carseller1.Data;
using carseller1.Models;
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

        public List<User> FindAll()
        {
            return _context.User.OrderBy(x => x.Name).ToList();
        }

        public void Insert(User obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public User FindById(int id)
        {
            return _context.User.FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.User.Find(id);
            _context.User.Remove(obj);
            _context.SaveChanges();
        }
    }
}
