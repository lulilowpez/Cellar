using Data.Entities;
using Data.Repositories.Interfaces;

namespace Data.Repositories.Repositories
{
    public class URepository : IUserRepository//me da error si no implmento todos los metodos de la interfaz
    {
        private readonly CellarContext _cellarContext;
        public URepository(CellarContext cellarContext)
        {
            _cellarContext = cellarContext;
        }
        public void AddUser(User user)
        {
           _cellarContext.Users.Add(user);//a la lista que le agregue en el contexto le agrega ese usuario
            _cellarContext.SaveChanges();
        }
        public User? GetCredentials(string password, string username)
        {
            return _cellarContext.Users
                .FirstOrDefault(a => a.UserName == username && a.Password == password);
        }
    }
}
