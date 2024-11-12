
using Common.DTOs;
using Data.Entities;

namespace Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> ExistsByUsernameAsync(string username);
        void Add(User user);
        void CreateUser(CreateUserDto dto);
    }
}
