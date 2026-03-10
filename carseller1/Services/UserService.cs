using carseller1.Data;
using carseller1.Models;

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
    }
}
