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

        public void CreateUser(CreateUserDto dto) 
        {
            //crea una nueva instancia de un usuario user 
            User newUser = new User()
            { 
                UserName = dto.UserName,
                Password = dto.Password
            };
            _userRepository.AddUser(newUser);
        }
        public User? ValidateUser(AuthDto auth)
        {
            return _userRepository.GetCredentials(auth.Password, auth.UserName);
        }

    }
}
