using Common.DTOs;
using Data.Entities;
using Data.Repositories.Interfaces;
using Data.Repositories.Repositories;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using System.Linq;

namespace Services.Services
{
    public class CService : ICataService
    {
        private readonly ICataRepository _cataRepository;
        private readonly IWineRepository _wineRepository;
        public CService(ICataRepository cataRepository, IWineRepository wineRepository)
        {
            _cataRepository = cataRepository;
            _wineRepository = wineRepository;
        }
        public void CreateCata(CreateCataDto dto)
        {
            var wines = _wineRepository.GetAllWines()
                .Where(w => dto.WineList.Contains(w.Id)).ToList();

            if (wines.Count() != dto.WineList.Count)
            {
                throw new ArgumentException("Uno o más nombres de vinos no son válidos.");
            }
            var cata = new Cata
            {
                Name = dto.Name,
                GuestList = dto.GuestList,
                Date = dto.Date,
                WineList = wines.ToList(),
            };
            _cataRepository.AddCata(cata);
        }

        public List<GetAllCatasDto> GetAll()
        {
            var catas = _cataRepository.GetAll()
                .Include(c => c.WineList) // Asegura que las relaciones se carguen
                .ToList();

            return catas.Select(cata => new GetAllCatasDto
            {
                Date = cata.Date,
                Name = cata.Name,
                WineList = cata.WineList.Select(w => w.Id).ToList(), // Deriva los IDs de los vinos
                GuestList = cata.GuestList
            }).ToList();
        }

        public void UpdateGuestList(int cataId, List<string> newGuest)
        {
            if (newGuest == null || !newGuest.Any())
            {
                throw new ArgumentException("Lista de invitados obligatoria, ingrese invitados.", nameof(newGuest));
            }
            _cataRepository.UpdateGuestList(cataId, newGuest);
        }
    }
}
