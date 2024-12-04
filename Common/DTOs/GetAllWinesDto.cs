using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Common.DTOs
{
    public class GetAllWinesDto
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } =string.Empty;
        public int Stock { get; set; }
        public int Year { get; set; }
        public string Region { get; set; } = string.Empty;
        public string Variety { get; set; } = string.Empty;
    }
}
