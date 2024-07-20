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
            builder.HasData(
           new Publisher
           {
               PublisherId = 1,
               PublisherName = "Pearson",
               ContactName = "John Pearson",
               Email = "contact@pearson.com",
               PhoneNumber = "123-456-7890",
               Country = "USA"
           },
           new Publisher
           {
               PublisherId = 2,
               PublisherName = "Penguin Random House",
               ContactName = "Jane Random",
               Email = "info@penguinrandomhouse.com",
               PhoneNumber = "987-654-3210",
               Country = "UK"
           },
           new Publisher
           {
               PublisherId = 3,
               PublisherName = "HarperCollins",
               ContactName = "Alice Harper",
               Email = "support@harpercollins.com",
               PhoneNumber = "555-123-4567",
               Country = "USA"
           },
           new Publisher
           {
               PublisherId = 4,
               PublisherName = "Simon & Schuster",
               ContactName = "Bob Simon",
               Email = "service@simonandschuster.com",
               PhoneNumber = "555-987-6543",
               Country = "USA"
           },
           new Publisher
           {
               PublisherId = 5,
               PublisherName = "Macmillan",
               ContactName = "Carol Macmillan",
               Email = "help@macmillan.com",
               PhoneNumber = "555-654-3210",
               Country = "UK"
           },
           new Publisher
           {
               PublisherId = 6,
               PublisherName = "Hachette Livre",
               ContactName = "David Hachette",
               Email = "info@hachette.com",
               PhoneNumber = "555-321-9876",
               Country = "France"
           },
           new Publisher
           {
               PublisherId = 7,
               PublisherName = "Scholastic",
               ContactName = "Eva Scholastic",
               Email = "contact@scholastic.com",
               PhoneNumber = "555-789-1234",
               Country = "USA"
           },
           new Publisher
           {
               PublisherId = 8,
               PublisherName = "Bloomsbury",
               ContactName = "Frank Bloomsbury",
               Email = "info@bloomsbury.com",
               PhoneNumber = "555-456-7890",
               Country = "UK"
           }
       );
        }
    }
}
