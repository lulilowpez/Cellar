
using Common.DTOs;
using Data.Entities;

namespace Services.Interfaces
{
    public interface IUserService
    {
        void CreateUser(CreateUserDto dto);
        User? ValidateUser(AuthDto auth);
    }
}
