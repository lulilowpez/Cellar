using System.ComponentModel.DataAnnotations;

namespace Common.DTOs
{
    public class AuthDto
    {
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;

    }
}
