using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(e => e.RoleId);
            builder.Property(e => e.RoleName).IsRequired().HasMaxLength(50);
            builder.Property(e => e.RoleDescription).HasMaxLength(200);
            builder.HasData(
                new Role { RoleId = 1, RoleName = "Admin", RoleDescription = "Administrator role" },
                new Role { RoleId = 2, RoleName = "User", RoleDescription = "Customer role" }
            );
        }
    }
}
