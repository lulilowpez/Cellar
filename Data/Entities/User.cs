using Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nombre de usuario es obligatorio")]
        public string UserName { get; set; } = string.Empty;
        [MinLength(8)]
        public required string Password { get; set; }//solo si hago cambio en entidades hago nueva migration
        public Role Rol {  get; set; }

    }
}