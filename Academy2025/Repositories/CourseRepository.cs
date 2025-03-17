using Academy2025.Repositories;
using Academy2025.Data;
using Microsoft.EntityFrameworkCore;

namespace Academy2025.Respositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<Course>> GetAllAsync()
        {
            return _context.Courses.ToListAsync();
        }

        public Task<Course?> GetByIdAsync(int id)
        {
            return _context.Courses.FirstOrDefaultAsync(Course => Course.Id == id);
        }

        public async Task CreateAsync(Course data)
        {
            await _context.Courses.AddAsync(data);
            await _context.SaveChangesAsync();
        }

        public Task<int> UpdateAsync()
        => _context.SaveChangesAsync();

        public async Task<bool> DeleteAsync(int id)
        {
            var Course = await _context.Courses.FirstOrDefaultAsync(Course => Course.Id == id);
            if (Course != null)
            {
                _context.Courses.Remove(Course);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}