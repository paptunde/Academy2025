﻿using System.ComponentModel.DataAnnotations;

namespace Academy2025.Data
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        [Required]
        [StringLength(50)]
        public DateTime? Birth { get; set; }

        public string? Role {  get; set; }

        public ICollection<Course> Courses { get; set; } = [];
        public ICollection<Course> AuthoredCourses { get; set; } = [];

        public required string Email {  get; set; }

        public required string Password { get; set; }

        public required string HashedPassword { get; set; }
    }
}
