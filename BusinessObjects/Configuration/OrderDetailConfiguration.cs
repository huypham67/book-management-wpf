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
            builder.HasOne(e => e.Order)
                  .WithMany(o => o.OrderDetails)
                  .HasForeignKey(e => e.OrderId);
            builder.HasOne(e => e.Book)
                  .WithMany(b => b.OrderDetails)
                  .HasForeignKey(e => e.BookId);
            builder.HasData(
            new OrderDetail
            {
                OrderId = 1,
                BookId = 1,
                Quantity = 2,
                UnitPrice = 19.99m
            },
            new OrderDetail
            {
                OrderId = 1,
                BookId = 3,
                Quantity = 1,
                UnitPrice = 15.99m,
            },
            new OrderDetail
            {
                OrderId = 2,
                BookId = 2,
                Quantity = 1,
                UnitPrice = 29.99m,
            },
            new OrderDetail
            {
                OrderId = 3,
                BookId = 4,
                Quantity = 1,
                UnitPrice = 12.99m,
            },
            new OrderDetail
            {
                OrderId = 4,
                BookId = 5,
                Quantity = 3,
                UnitPrice = 18.99m,
            },
            new OrderDetail
            {
                OrderId = 5,
                BookId = 6,
                Quantity = 2,
                UnitPrice = 22.99m
            },
            new OrderDetail
            {
                OrderId = 6,
                BookId = 7,
                Quantity = 1,
                UnitPrice = 25.99m
            },
            new OrderDetail
            {
                OrderId = 7,
                BookId = 8,
                Quantity = 1,
                UnitPrice = 30.99m
            });
        }
    }
}
