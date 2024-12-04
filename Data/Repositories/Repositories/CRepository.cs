using Data.Entities;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Repositories
{
    public class CRepository : ICataRepository

    {
        private readonly CellarContext _cellarContext;
        public CRepository(CellarContext cellarContext)
        {
            _cellarContext = cellarContext;
        }
        public void AddCata(Cata cata)
        {
            _cellarContext.Catas.Add(cata);
            _cellarContext.SaveChanges();
        }

        public Cata GetById(int id)
        {
            return _cellarContext.Catas.Include(c => c.WineList).FirstOrDefault(c => c.Id == id);
        }
        public IQueryable<Cata> GetAll()
        {
            return _cellarContext.Catas.AsQueryable();
        }

        public async Task AddAsync(Cata cata)
        {
            await _cellarContext.Catas.AddAsync(cata);
            await _cellarContext.SaveChangesAsync();
        }

        public void UpdateGuestList(int cataId, List<string> NewGuestList)
        {
            var existingCata = _cellarContext.Catas.FirstOrDefault(c => c.Id == cataId);
            if (existingCata != null)
            {
                existingCata.GuestList = NewGuestList;
                _cellarContext.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException($"Cata {cataId} no encontrada.");
            }
        }

        public Cata GetById(string variety)
        {
            throw new NotImplementedException();
        }

       
    }
}
