using Data.Entities;

namespace Data.Repositories.Interfaces
{
    public interface ICataRepository
    {
        void AddCata(Cata cata);
        Cata GetById(string variety);
        Task AddAsync(Cata cata);
        void UpdateGuestList(int cataId, List <string> NewGuestList);
        IQueryable<Cata> GetAll();
    }
}
