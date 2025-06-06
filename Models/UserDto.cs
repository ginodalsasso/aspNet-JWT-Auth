﻿using System.ComponentModel.DataAnnotations;

namespace aspNet_JWT_Auth.Models
{
    public class UserDto
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        [RegularExpression("^[a-zA-Z0-9_]+$", 
            ErrorMessage = "Username is invalid")]
        public string Username { get; set; } = string.Empty;

        [Required]
        [MinLength(8)]
        [MaxLength(256)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&]).{12,}$",
            ErrorMessage = "Password must be at least 12 characters long, contain at least one uppercase letter, one digit, and one special character")]
        public string PasswordHash { get; set; } = string.Empty;
    }
}
