using Academy2025.Dtos;

namespace Academy2025.Services
{
    public interface ICourseService
    {
        Task CreateAsync(CourseDto data);
        Task<bool> DeleteAsync(int id);
        Task<List<CourseDto>> GetAllAsync();
        Task<CourseDto?> GetByIdAsync(int id);
        Task<CourseDto?> UpdateAsync(int id, CourseDto data);
    }
}
