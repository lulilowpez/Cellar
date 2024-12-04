using Common.DTOs;

namespace Services.Interfaces
{
    public interface IWineService
    {
        List<GetAllWinesDto> GetAllWines();
        void CreateWine(CreateWineDto dto);
        int GetStock(string variety);
        void UpdateStock(UpdateStockDto dto, int wineId);
        bool CheckIfWineExists(int wineId);
    }
}
