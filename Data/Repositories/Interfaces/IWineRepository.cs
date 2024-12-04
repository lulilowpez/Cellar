using Data.Entities;

namespace Data.Repositories.Interfaces
{
    public interface IWineRepository
    {
        void AddWine(Wine wine);
        List<Wine> GetAllWines();
        bool CheckWine(int WineId);
        List<Wine> GetStock(string variety);
        void UpdateStock(int wineId, int stock);
    }
}
