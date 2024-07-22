using BusinessObjects.Models;
using DataAccessLayer.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.RoleRepositories
{
    public class RoleRepository : IRoleRepository
    {
        public IEnumerable<Role> GetRoles()
                => RoleDAO.Instance.GetRoles();
        public Role? GetRoleById(int id) 
                => RoleDAO.Instance.GetRoleById(id);

        public void AddRole(Role role)
                => RoleDAO.Instance.AddRole(role);

        public void UpdateRole(Role role)
                => RoleDAO.Instance.UpdateRole(role);

        public void DeleteRole(Role role)
                => RoleDAO.Instance.DeleteRole(role);
    }
}
