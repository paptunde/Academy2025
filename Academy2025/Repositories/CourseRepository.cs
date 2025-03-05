using Academy2025.Data;
using System.Net.Cache;
using System.Security.Cryptography.X509Certificates;

namespace Academy2025.Respositories
{
    public class CourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository()
        {
            _context = new ApplicationDbContext();
        }

        public List<Course> GetAll()
        {
            return _context.Courses.ToList();
        }

        public Course? GetById(int id)
        {
            return _context.Courses.FirstOrDefault(Course => Course.Id == id);
        }

        public void Create(Course data)
        {
            _context.Courses.Add(data);
            _context.SaveChanges();
        }

        public Course? Update(int id, Course data)
        {
            var Course = _context.Courses.FirstOrDefault(Course => Course.Id == id);
            if (Course != null)
            {
                Course.Name = data.Name;
                Course.desctiption = data.desctiption;
                _context.SaveChanges();

                return Course;
            }

            return null;
        }

        public bool Delete(int id)
        {
            var Course = _context.Courses.FirstOrDefault(Course => Course.Id == id);
            if (Course != null)
            {
                _context.Courses.Remove(Course);
                _context.SaveChanges();

                return true;
            }

            return false;
        }
    }
}