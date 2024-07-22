using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.AdminRepositories
{
    public interface IAdminRepository
    {
        bool GetAdminAccount(string email, string password);
    }
}
