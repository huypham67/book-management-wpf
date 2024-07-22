using DataAccessLayer;
using DataAccessLayer.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.AdminRepositories
{
    public class AdminRepository : IAdminRepository
    {
        public bool GetAdminAccount(string email, string password) => AdminDAO.Instance.GetAdminAccount(email, password);
    }
}
