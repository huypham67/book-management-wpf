using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.UserRepositories
{
    public interface IUserRepository
    {
        IEnumerable<UserAccount> GetUsers();
        UserAccount? CheckLogin(string email, string password);
        UserAccount? GetUserById(int id);
        void AddUser(UserAccount user);
        void UpdateUser(UserAccount user);
        void DeleteUser(UserAccount user);
    }
}
