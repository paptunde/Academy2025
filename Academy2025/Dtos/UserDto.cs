﻿using Academy2025.Data;
using System.ComponentModel.DataAnnotations;

namespace Academy2025.Dtos
{
    public class UserDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        [Required]
        public DateTime? Birth { get; set; }

        public string? Role { get; set; }

        [EmailAddress]
        public required string Email { get; set; }

        public required string Password { get; set; }

    }
}