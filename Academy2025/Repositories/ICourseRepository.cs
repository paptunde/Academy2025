using Academy2025.Data;

namespace Academy2025.Repositories
{
    public interface ICourseRepository
    {
        Task CreateAsync(Course course);
        Task<bool> DeleteAsync(int id);
        Task<List<Course>> GetAllAsync();
        Task<int> UpdateAsync();
        Task<Course?> GetByIdAsync(int id);
    }
}
