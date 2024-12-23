﻿using System.ComponentModel.DataAnnotations;

namespace Common.DTOs
{
    public class CreateUserDto
    {
        [Required]
        public string UserName { get; set; } = string.Empty;
        [MinLength(8)]
        public required string Password { get; set; }
    }
}
