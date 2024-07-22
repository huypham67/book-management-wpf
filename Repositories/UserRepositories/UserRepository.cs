using BusinessObjects.Models;
using DataAccessLayer.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.UserRepositories
{
    public class UserRepository : IUserRepository
    {
        public IEnumerable<UserAccount> GetUsers()
                        => UserDAO.Instance.GetUsers();
        public UserAccount? CheckLogin(string email, string password)
                        => UserDAO.Instance.CheckLogin(email, password);
        public UserAccount? GetUserById(int id)
                        => UserDAO.Instance.GetUserById(id);

        public void AddUser(UserAccount user)
                        => UserDAO.Instance.AddUser(user);

        public void UpdateUser(UserAccount user)
                        => UserDAO.Instance.UpdateUser(user);

        public void DeleteUser(UserAccount user)
                        => UserDAO.Instance.DeleteUser(user);
    }
}
