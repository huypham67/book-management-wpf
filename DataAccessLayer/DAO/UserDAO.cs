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
            return _context.Users.Include(user => user.Role).SingleOrDefault(u => u.UserId == id);
        }
        public UserAccount? GetUserByEmail(string email)
        {
            _context = new();
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }
        public UserAccount? CheckLogin(string email, string password)
        {
            _context = new();
            return _context.Users.Include(user => user.Role).FirstOrDefault(u => u.Email == email && u.PasswordHash == password);
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
            var existingUser = _context.Books.Find(u.UserId);
            if (existingUser != null)
            {
                _context.Entry(existingUser).CurrentValues.SetValues(existingUser);
                _context.SaveChanges();
            }
        }
        public void DeleteUser(UserAccount u)
        {
            _context = new();
            _context.Remove(u);
            _context.SaveChanges();
        }
        public bool ChangePassword(int userId, string newPassword)
        {
            _context = new();
            UserAccount? user = _context.Users.SingleOrDefault(user => user.UserId == userId);
            if (user != null)
            {
                user.PasswordHash = newPassword;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool CheckCurrentPassword(int userId, string currentPassword)
        {
            _context = new();
            UserAccount? user = _context.Users.SingleOrDefault(user => user.UserId == userId);
            return user != null && user.PasswordHash == currentPassword;
        }
    }
}
