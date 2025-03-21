using System.ComponentModel.DataAnnotations;

namespace Academy2025.Data
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public ICollection<User> Users { get; set; } = [];

        public int? AuthorId { get; set; }

        public User? Author { get; set; }
    }
}
