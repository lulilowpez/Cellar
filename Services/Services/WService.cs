using Common.DTOs;
using Data.Entities;
using Data.Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Services
{
    public class WService : IWineService
    {
        private readonly IWineRepository _wineRepository;
        public WService(IWineRepository wineRepository)
        {
            _wineRepository = wineRepository;
        }
        public void CreateWine(CreateWineDto dto)
        {
            Wine newWine = new Wine()
            {
                Name = dto.Name,
                Region = dto.Region,
                Year = dto.Year,
                Stock = dto.Stock,
                Variety = dto.Variety,
            };
            _wineRepository.AddWine(newWine);
        }

        public List<GetAllWinesDto> GetAllWines()
        {
            var wines = _wineRepository.GetAllWines();
            return wines.Select(w => new GetAllWinesDto
            {
                Id = w.Id,
                Name = w.Name,
                Variety = w.Variety,
                Year = w.Year,
                Region = w.Region,
                Stock = w.Stock
            }).ToList();
        }
        public int GetStock(string variety)
        {
            // Llamamos al método del repositorio para obtener los vinos filtrados
            var wines = _wineRepository.GetStock(variety);

            // Sumamos directamente el stock de la variedad especificada
            var totalStock = wines.Sum(w => w.Stock);

            return totalStock;
        }

        public bool CheckIfWineExists(int wineId)
        {
            return _wineRepository.CheckWine(wineId);
        }
        public void UpdateStock(UpdateStockDto dto, int wineId)
        {
            if (dto.Stock < 0)
                throw new ArgumentException("Ingrese un valor válido mayor que cero");
                _wineRepository.UpdateStock(wineId, dto.Stock);
        }
    }

}
    




