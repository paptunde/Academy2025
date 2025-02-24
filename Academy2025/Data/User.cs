﻿using System.ComponentModel.DataAnnotations;

namespace Academy2025.Data
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? FirstName { get; set; }

		[Required]
		[StringLength(50)]
		public string? LastName { get; set; }

    }
}
