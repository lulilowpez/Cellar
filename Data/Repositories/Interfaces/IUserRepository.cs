using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> ExistsByUsernameAsync(string username);
        void AddUser(User user);
        Task SaveChangesAsync();
    }
}
