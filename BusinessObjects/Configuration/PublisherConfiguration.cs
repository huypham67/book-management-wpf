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
    public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.HasKey(e => e.PublisherId);
            builder.Property(e => e.PublisherName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.ContactName).HasMaxLength(100);
            builder.Property(e => e.Email).IsRequired().HasMaxLength(100);
            builder.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(15);
            builder.Property(e => e.Country).HasMaxLength(50);
        }
    }
}
