using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Configuration
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(e => e.AuthorId);
            builder.Property(e => e.AuthorName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Biography).HasMaxLength(1000);
            builder.Property(e => e.DateOfBirth).IsRequired();
            builder.Property(e => e.Nationality).HasMaxLength(50);
        }
    }
}
