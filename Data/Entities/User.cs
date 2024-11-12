using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nombre de usuario es obligatorio")]
        public required string UserName { get; set; }
        [MinLength(8)]
        public required string Password { get; set; }

    }
}
