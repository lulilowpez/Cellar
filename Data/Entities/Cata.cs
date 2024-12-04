using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class Cata
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //autoincrementable
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<string> GuestList { get; set; } = new List<string>();//instancio lista porque sino el valor es null hasta que asigne un valor
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public List<Wine> WineList { get; set; } = new List<Wine>();
    }

}
