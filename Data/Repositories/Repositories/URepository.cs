using Data.Entities;
using Data.Repositories.Interfaces;

namespace Data.Repositories.Repositories
{
    public class URepository : IUserRepository
    {
        private readonly List<User> Users;
        public URepository()
        {
            Users = new List<User>();
            User user1 = new User()
            {
                Id = 1,
                UserName = "Luli",
                Password = "060292",
            };
            Users.Add(user1);
            User user2 = new User()
            {
                Id = 2,
                UserName = "Melo",
                Password = "120710",
            };
            Users.Add(user2);
            User user3 = new User()
            {
                Id = 3,
                UserName = "Coraline",
                Password = "021124",
            };
            Users.Add(user3);
        {
            throw new NotImplementedException();
        }
    }
        public void AddUser(User user)
        {
            Users.Add(user);
        }

        public Task<bool> ExistsByUsernameAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
