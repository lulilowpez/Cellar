using Data.Entities;

namespace Common.DTOs
{
    public class GetAllCatasDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public List<int> WineList { get; set; } = new List<int>();
        public List<string> GuestList { get; set; } = new List<string>();
    }
}
