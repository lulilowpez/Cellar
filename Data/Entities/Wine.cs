using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Wine
    {
        public int Id { get; set; };
        [Required]
        public string Name { get; set; }
        [Range(1880, 2024, ErrorMessage = "Debe arrojar año de cosecha entre 1880 y 2024")]
        public int Year { get; set; }
        public string Origin { get; set; }
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
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public void AddStock (int amount)
        {
            if (amount <= 0) throw new ArgumentException("La cantidad a añadir debe ser mayor a 0");
            Stock -= amount;
        }
    }
}
