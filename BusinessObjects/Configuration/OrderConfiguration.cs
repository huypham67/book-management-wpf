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
            builder.HasData(
            new Order
            {
                OrderId = 1,
                OrderDate = new DateTime(2023, 1, 15),
                OrderStatus = OrderStatus.Pending,
                UserId = 1
            },
            new Order
            {
                OrderId = 2,
                OrderDate = new DateTime(2023, 2, 20),
                OrderStatus = OrderStatus.Confirmed,
                UserId = 2
            },
            new Order
            {
                OrderId = 3,
                OrderDate = new DateTime(2023, 3, 10),
                OrderStatus = OrderStatus.Confirmed,
                UserId = 3
            },
            new Order
            {
                OrderId = 4,
                OrderDate = new DateTime(2023, 4, 5),
                OrderStatus = OrderStatus.Pending,
                UserId = 4
            },
            new Order
            {
                OrderId = 5,
                OrderDate = new DateTime(2023, 5, 25),
                OrderStatus = OrderStatus.Pending,
                UserId = 5
            },
            new Order
            {
                OrderId = 6,
                OrderDate = new DateTime(2023, 6, 15),
                OrderStatus = OrderStatus.Confirmed,
                UserId = 6
            },
            new Order
            {
                OrderId = 7,
                OrderDate = new DateTime(2023, 7, 20),
                OrderStatus = OrderStatus.Confirmed,
                UserId = 7
            },
            new Order
            {
                OrderId = 8,
                OrderDate = new DateTime(2023, 8, 30),
                OrderStatus = OrderStatus.Pending,
                UserId = 8
            }
        );
        }
    }
}
