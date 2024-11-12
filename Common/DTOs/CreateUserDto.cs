
using System.ComponentModel.DataAnnotations;

namespace Common.DTOs
{
    public class CreateUserDto
    {
        public required string UserName { get; set; }
        [MinLength(8)]
        public required string Password { get; set; }
    }
}
