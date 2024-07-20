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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(e => e.OrderId);
            builder.Property(e => e.OrderDate).IsRequired();
            builder.Property(e => e.OrderStatus).IsRequired().HasMaxLength(20);
            builder.HasOne(e => e.User)
                  .WithMany(u => u.Orders)
                  .HasForeignKey(e => e.UserId);
        }
    }
}
