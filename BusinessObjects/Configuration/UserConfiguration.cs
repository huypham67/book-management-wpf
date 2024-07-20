using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.UserId);
            builder.Property(e => e.FullName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.DateOfBirth).IsRequired();
            builder.Property(e => e.Email).IsRequired().HasMaxLength(100);
            builder.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(15);
            builder.Property(e => e.PasswordHash).IsRequired();
            builder.Property(e => e.Status).IsRequired().HasMaxLength(20);
            builder.HasOne(e => e.Role)
                          .WithMany(r => r.Users)
                          .HasForeignKey(e => e.RoleId);
            builder.HasData(
            new User
            {
                UserId = 1,
                FullName = "John Doe",
                DateOfBirth = new DateTime(1985, 5, 15),
                Email = "john.doe@example.com",
                PhoneNumber = "123-456-7890",
                PasswordHash = "hashed_password_1",
                Status = UserStatus.Active,
                RoleId = 1
            },
            new User
            {
                UserId = 2,
                FullName = "Jane Smith",
                DateOfBirth = new DateTime(1990, 10, 25),
                Email = "jane.smith@example.com",
                PhoneNumber = "987-654-3210",
                PasswordHash = "hashed_password_2",
                Status = UserStatus.Deleted,
                RoleId = 2
            },
            new User
            {
                UserId = 3,
                FullName = "Alice Johnson",
                DateOfBirth = new DateTime(1988, 3, 22),
                Email = "alice.johnson@example.com",
                PhoneNumber = "555-123-4567",
                PasswordHash = "hashed_password_3",
                Status = UserStatus.Active,
                RoleId = 2
            },
            new User
            {
                UserId = 4,
                FullName = "Bob Brown",
                DateOfBirth = new DateTime(1975, 12, 10),
                Email = "bob.brown@example.com",
                PhoneNumber = "555-987-6543",
                PasswordHash = "hashed_password_4",
                Status = UserStatus.Deleted,
                RoleId = 1
            },
            new User
            {
                UserId = 5,
                FullName = "Carol White",
                DateOfBirth = new DateTime(1995, 7, 30),
                Email = "carol.white@example.com",
                PhoneNumber = "555-654-3210",
                PasswordHash = "hashed_password_5",
                Status = UserStatus.Active,
                RoleId = 2
            },
            new User
            {
                UserId = 6,
                FullName = "David Green",
                DateOfBirth = new DateTime(1982, 11, 5),
                Email = "david.green@example.com",
                PhoneNumber = "555-321-9876",
                PasswordHash = "hashed_password_6",
                Status = UserStatus.Active,
                RoleId = 1
            },
            new User
            {
                UserId = 7,
                FullName = "Eva Black",
                DateOfBirth = new DateTime(2000, 4, 18),
                Email = "eva.black@example.com",
                PhoneNumber = "555-789-1234",
                PasswordHash = "hashed_password_7",
                Status = UserStatus.Deleted,
                RoleId = 2
            },
            new User
            {
                UserId = 8,
                FullName = "Frank Blue",
                DateOfBirth = new DateTime(1998, 2, 14),
                Email = "frank.blue@example.com",
                PhoneNumber = "555-456-7890",
                PasswordHash = "hashed_password_8",
                Status = UserStatus.Active,
                RoleId = 1
            }
        );
        }
    }
    
}
