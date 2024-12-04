using Data.Entities;
using Data.Repositories.Interfaces;

namespace Data.Repositories.Repositories
{
    public class WRepository : IWineRepository

    {
        private readonly CellarContext _cellarContext;
        public WRepository(CellarContext cellarContext)
        {
            _cellarContext = cellarContext;
        }
        public bool CheckWine(int WineId)
        {
            var wine = _cellarContext.Wines.FirstOrDefault(u => u.Id == WineId);
            return wine != null;
        }

        public void AddWine(Wine wine)
        {
            _cellarContext.Wines.Add(wine);
            _cellarContext.SaveChanges();
        }
        public List<Wine> GetAllWines()
        {
            return _cellarContext.Wines.ToList();
        }
        public List<Wine> GetStock(string variety)
        { 
            return _cellarContext.Wines.
                 Where(w => w.Variety.ToLower() == variety.ToLower() && w.Stock > 0).ToList();
        }
        public void UpdateStock(int wineId, int stock)
        {
            var wine = _cellarContext.Wines.FirstOrDefault(w => w.Id == wineId);
            if (wine == null) {
                throw new Exception("El vino ingresado no existe");
            }
            wine.Stock = stock;
            _cellarContext.SaveChanges();
        }

      
    }
}
