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
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(e => e.BookId);
            builder.Property(e => e.BookName).IsRequired().HasMaxLength(200);
            builder.Property(e => e.BookDescription).HasMaxLength(1000);
            builder.Property(e => e.PublicationDate).IsRequired();
            builder.Property(e => e.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(e => e.Quantity).IsRequired();
            builder.HasOne(e => e.Author)
                  .WithMany(a => a.Books)
                  .HasForeignKey(e => e.AuthorId);
            builder.HasOne(e => e.BookCategory)
                  .WithMany(bc => bc.Books)
                  .HasForeignKey(e => e.BookCategoryId);
            builder.HasOne(e => e.Publisher)
                  .WithMany(p => p.Books)
                  .HasForeignKey(e => e.PublisherId);
        }
    }
}
