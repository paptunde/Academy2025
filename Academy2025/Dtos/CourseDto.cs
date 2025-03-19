using Academy2025.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Academy2025.Dtos
{
    public class CourseDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public ICollection<UserDto> Users { get; set; } = [];

        [Required]
        public int? Author { get; set; }
    }
}
