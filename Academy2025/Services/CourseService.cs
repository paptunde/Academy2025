using Academy2025.Data;
using Academy2025.Dtos;
using Academy2025.Repositories;
using Academy2025.Respositories;

namespace Academy2025.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _CourseRepository;

        public CourseService(ICourseRepository CourseRepository)
        {
            _CourseRepository = CourseRepository;
        }

        public Task CreateAsync(CourseDto data)
            => _CourseRepository.CreateAsync(MapToModel(data));

        public Task<bool> DeleteAsync(int id)
            => _CourseRepository.DeleteAsync(id);

        public async Task<List<CourseDto>> GetAllAsync()
        {
            var Courses = await _CourseRepository.GetAllAsync();

            return Courses.Select(MapToDto).ToList();
        }

        public async Task<CourseDto?> GetByIdAsync(int id)
        {
            var Course = await _CourseRepository.GetByIdAsync(id);
            return Course != null ? MapToDto(Course) : null;
        }

        public async Task<CourseDto?> UpdateAsync(int id, CourseDto data)
        {
            var Course = await _CourseRepository.GetByIdAsync(id);

            if (Course != null)
            {
                Course.Name = data.Name;

                await _CourseRepository.UpdateAsync();
            }

            return Course != null ? MapToDto(Course) : null;
        }

        private static CourseDto MapToDto(Course Course) => new()
        {
            Id = Course.Id,
            Name = Course.Name,
            AuthorId = Course.AuthorId
        };

        private static Course MapToModel(CourseDto CourseDto) => new()
        {
            Id = CourseDto.Id,
            Name = CourseDto.Name,
            AuthorId = CourseDto.AuthorId
        };
    }
}
