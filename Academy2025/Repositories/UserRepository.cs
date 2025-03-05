using Academy2025.Data;
using System.Net.Cache;
using System.Security.Cryptography.X509Certificates;

namespace Academy2025.Respositories
{
    public class UserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository()
        {
            _context = new ApplicationDbContext();
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User? GetById(int id)
        {
            return _context.Users.FirstOrDefault(user => user.Id == id);
        }

        public void Create(User data)
        {
            _context.Users.Add(data);
            _context.SaveChanges();
        }

        public User? Update(int id, User data)
        {
            var user = _context.Users.FirstOrDefault(user => user.Id == id);
            if (user != null)
            {
                user.FirstName = data.FirstName;
                user.LastName = data.LastName;
                user.Birth = data.Birth;
                _context.SaveChanges();

                return user;
            }

            return null;
        }

        public void Age(User data)
        {
            var d = DateTime.Now.AddYears(-18);

            IEnumerable<User> B = from u in _context.Users
                                    where u.Birth < d
                                    select data;
           
            foreach (var s in B)
            {
                Console.WriteLine(s);
            }
        }

        public bool Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(user => user.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();

                return true;
            }

            return false;
        }
    }
}