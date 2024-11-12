using Data.Entities;
using Data.Repositories.Interfaces;

namespace Data.Repositories.Repositories
{
    public class WRepository : IWineRepository

    {
        private readonly List<Wine> Wines;
        public WRepository()
        {
            Wines = new List<Wine>();
            Wine wine1 = new Wine();
            {
                Name = "Dada",
                Year = 2021,
                Origin = "Mendoza" ,
                Stock = 200
            };
            Wines.Add(wine1);

            Wine wine2= new Wine();
            {
                Name = "Dadas,
                Year = 2020,
                Origin = "Mendozas",
                Stock = 20
            };
            Wines.Add(wine2);
        }

        public void AddWine(Wine wine)
        {
            Wines.Add(wine);
        }

        public List<Wine> GetAllWines()
        {
            return Wines;
        }
    }
}
