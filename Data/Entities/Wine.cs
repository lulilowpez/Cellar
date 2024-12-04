using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class Wine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Variety { get; set; } = string.Empty;
        [Range(1880, 2024, ErrorMessage = "Debe arrojar año de cosecha entre 1880 y 2024")]
        public int Year { get; set; }
        public required string Region { get; set; } = string.Empty;
        private int _stock;
        public int Stock
        {
            get => _stock;
            set
            {
                if (value < 0) throw new ArgumentException("El stock no puede ser negativo");
                _stock = value;
            }
        }
        public List<Cata> Catas { get; set; } = new List<Cata>();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public void AddStock (int amount)
        {
            if (amount <= 0) throw new ArgumentException("La cantidad a añadir debe ser mayor a 0");
            Stock += amount;
        }
        public void RemoveStock(int amount)
        {
            if (amount <= 0) throw new ArgumentException("La cantidad a reducir debe ser mayor a 0.");
            if (Stock - amount < 0) throw new InvalidOperationException("No hay suficiente stock disponible.");
            Stock -= amount;
        }
        
    }


}
