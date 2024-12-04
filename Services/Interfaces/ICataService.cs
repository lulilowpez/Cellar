using Common.DTOs;
using Data.Entities;

namespace Services.Interfaces
{
   public interface ICataService
    {
        void CreateCata(CreateCataDto dto);
        public void UpdateGuestList(int cataId, List<string> newGuest);
        public List<GetAllCatasDto> GetAll();
    }
}
