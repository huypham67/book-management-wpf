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
        public IEnumerable<User> GetUsers()
        {
            _context = new();
            return _context.Users;
        }
        public User? GetUserById(int id)
        {
            _context = new();
            return _context.Users.SingleOrDefault(u => u.UserId == id);
        }
        public User? GetUserByEmail(string email)
        {
            _context = new();
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }
        public void AddUser(User u)
        {
            _context = new();
            _context.Add(u);
            _context.SaveChanges();
        }
        public void UpdateUser(User u)
        {
            _context = new();
            _context.Update(u);
            _context.SaveChanges();
        }
        public void DeleteUser(User u)
        {
            _context = new();
            _context.Remove(u);
            _context.SaveChanges();
        }
    }
}
