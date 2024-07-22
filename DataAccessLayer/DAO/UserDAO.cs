using BusinessObjects;
using BusinessObjects.Models;
using DataAccessLayer.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DAO
{
    public class UserDAO : SingletonBase<UserDAO>
    {
        private BookManagementDbContext _context;
        public IEnumerable<UserAccount> GetUsers()
        {
            _context = new();
            return _context.Users.Include(u => u.Role);
        }
        public UserAccount? GetUserById(int id)
        {
            _context = new();
            return _context.Users.SingleOrDefault(u => u.UserId == id);
        }
        public UserAccount? GetUserByEmail(string email)
        {
            _context = new();
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }
        public UserAccount? CheckLogin(string email, string password)
        {
            _context = new();
            return _context.Users.FirstOrDefault(u => u.Email == email && u.PasswordHash == password);
        }
        public void AddUser(UserAccount u)
        {
            _context = new();
            _context.Add(u);
            _context.SaveChanges();
        }
        public void UpdateUser(UserAccount u)
        {
            _context = new();
            _context.Update(u);
            _context.SaveChanges();
        }
        public void DeleteUser(UserAccount u)
        {
            _context = new();
            _context.Remove(u);
            _context.SaveChanges();
        }
    }
}
