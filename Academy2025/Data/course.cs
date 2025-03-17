using System.ComponentModel.DataAnnotations;

namespace Academy2025.Data
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public ICollection<User> Users { get; set; } = [];

        public string? Author { get; set; }

    }
}
