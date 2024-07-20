using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string? FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PasswordHash { get; set; }
        public UserStatus Status { get; set; }
        public int RoleId { get; set; }
        public virtual Role? Role { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
    public enum UserStatus
    {
        Active, Deleted
    }
}
