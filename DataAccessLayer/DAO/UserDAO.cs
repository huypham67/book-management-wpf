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
        public User? GetCustomerByEmail(string email)
        {
            _context = new();
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }
        public void AddCustomer(Customer c)
        {
            _context = new();
            _context.Add(c);
            _context.SaveChanges();
        }
        public void UpdateCustomer(Customer c)
        {
            _context = new();
            _context.Update(c);
            _context.SaveChanges();
        }
        public void DeleteCustomer(Customer c)
        {
            _context = new();
            _context.Remove(c);
            _context.SaveChanges();
        }
    }
}
