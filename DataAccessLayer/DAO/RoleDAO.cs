using BusinessObjects.Models;
using BusinessObjects;
using DataAccessLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DAO
{
    public class RoleDAO : SingletonBase<RoleDAO>
    {
        private BookManagementDbContext _context;
        public IEnumerable<Role> GetRoles()
        {
            _context = new();
            return _context.Roles;
        }
        public Role? GetRoleById(int id)
        {
            _context = new();
            return _context.Roles.SingleOrDefault(r => r.RoleId == id);
        }
        public void AddRole(Role role)
        {
            _context = new();
            _context.Add(role);
            _context.SaveChanges();
        }
        public void UpdateRole(Role role)
        {
            _context = new();
            var existingRole = _context.Books.Find(role.RoleId);
            if (existingRole != null)
            {
                _context.Entry(existingRole).CurrentValues.SetValues(role);
                _context.SaveChanges();
            }

        }
        public void DeleteRole(Role role)
        {
            _context = new();
            _context.Remove(role);
            _context.SaveChanges();
        }
    }
}
