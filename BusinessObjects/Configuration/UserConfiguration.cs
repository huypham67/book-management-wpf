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
        }
    }
    
}
