using Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace Common.DTOs
{
    public class CreateCataDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public List<string> GuestList { get; set; } = new List<string>();
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public List<int> WineList { get; set; } = new List<int>();
    }
}
