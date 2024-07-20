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
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(e => new { e.OrderId, e.BookId });
            builder.Property(e => e.Quantity).IsRequired();
            builder.Property(e => e.UnitPrice).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(e => e.Discount).IsRequired().HasColumnType("decimal(18,2)");
            builder.HasOne(e => e.Order)
                  .WithMany(o => o.OrderDetails)
                  .HasForeignKey(e => e.OrderId);
            builder.HasOne(e => e.Book)
                  .WithMany(b => b.OrderDetails)
                  .HasForeignKey(e => e.BookId);
        }
    }
}
