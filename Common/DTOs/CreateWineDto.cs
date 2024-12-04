using System.ComponentModel.DataAnnotations;

namespace Common.DTOs
{
    public class CreateWineDto

    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Range(1880, 2024, ErrorMessage = "Debe arrojar año de cosecha entre 1880 y 2024")]
        public int Year { get; set; }
        public string Variety { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        [Range(0, int.MaxValue, ErrorMessage = "Ingrese stock mayor ó igual a 0")]
        public int Stock { get; set; }
    }
}
