using Common.DTOs;
using Services.Interfaces;
using Data.Repositories.Interfaces;
using Data.Entities;

namespace Services.Services
{
    public class UService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Add(User user)
        {
            throw new NotImplementedException();
        }

        public void CreateUser(CreateUserDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task CreateUserAsync(CreateUserDto dto)
        {
            bool exists = await _userRepository.ExistsByUsernameAsync(dto.UserName);
            if (exists)
            {
                throw new Exception("El nombre de usuario ya está en uso.");
            }
            User newUser = new User()
            {
                Username = dto.UserName,
                Password = dto.Password
            };
            _userRepository.AddUser(newUser);
            await _userRepository.SaveChangesAsync();

        }
        public Task<bool> ExistsByUsernameAsync(string username)
        {
            throw new NotImplementedException();
        }
    }
}
