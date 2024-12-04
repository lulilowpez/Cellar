using Data.Entities;

namespace Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        void AddUser(User user);
        User? GetCredentials(string password, string username);
    }
}
