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
            builder.HasData(
            new Book
            {
                BookId = 1,
                BookName = "1984",
                BookDescription = "A dystopian social science fiction novel and cautionary tale, written by the English writer George Orwell.",
                PublicationDate = new DateTime(1949, 6, 8),
                Price = 19.99m,
                Quantity = 100,
                AuthorId = 1,
                BookCategoryId = 1,
                PublisherId = 1
            },
            new Book
            {
                BookId = 2,
                BookName = "Harry Potter and the Philosopher's Stone",
                BookDescription = "A fantasy novel written by British author J.K. Rowling. It is the first book in the Harry Potter series.",
                PublicationDate = new DateTime(1997, 6, 26),
                Price = 29.99m,
                Quantity = 200,
                AuthorId = 2,
                BookCategoryId = 4,
                PublisherId = 2
            },
            new Book
            {
                BookId = 3,
                BookName = "The Old Man and the Sea",
                BookDescription = "A short novel written by the American author Ernest Hemingway in 1951 in Cuba, and published in 1952.",
                PublicationDate = new DateTime(1952, 9, 1),
                Price = 15.99m,
                Quantity = 150,
                AuthorId = 3,
                BookCategoryId = 1,
                PublisherId = 3
            },
            new Book
            {
                BookId = 4,
                BookName = "Pride and Prejudice",
                BookDescription = "A romantic novel of manners written by Jane Austen in 1813.",
                PublicationDate = new DateTime(1813, 1, 28),
                Price = 12.99m,
                Quantity = 120,
                AuthorId = 4,
                BookCategoryId = 7,
                PublisherId = 4
            },
            new Book
            {
                BookId = 5,
                BookName = "The Adventures of Tom Sawyer",
                BookDescription = "A novel written by Mark Twain about a young boy growing up along the Mississippi River.",
                PublicationDate = new DateTime(1876, 4, 30),
                Price = 18.99m,
                Quantity = 130,
                AuthorId = 5,
                BookCategoryId = 1,
                PublisherId = 5
            },
            new Book
            {
                BookId = 6,
                BookName = "Murder on the Orient Express",
                BookDescription = "A detective novel by British author Agatha Christie featuring the Belgian detective Hercule Poirot.",
                PublicationDate = new DateTime(1934, 1, 1),
                Price = 22.99m,
                Quantity = 140,
                AuthorId = 6,
                BookCategoryId = 3,
                PublisherId = 6
            },
            new Book
            {
                BookId = 7,
                BookName = "One Hundred Years of Solitude",
                BookDescription = "A landmark 1967 novel by Colombian author Gabriel Garcia Marquez that tells the multi-generational story of the Buendia family.",
                PublicationDate = new DateTime(1967, 6, 5),
                Price = 25.99m,
                Quantity = 160,
                AuthorId = 7,
                BookCategoryId = 1,
                PublisherId = 7
            },
            new Book
            {
                BookId = 8,
                BookName = "War and Peace",
                BookDescription = "A novel by the Russian author Leo Tolstoy, published from 1865 to 1869.",
                PublicationDate = new DateTime(1869, 1, 1),
                Price = 30.99m,
                Quantity = 170,
                AuthorId = 8,
                BookCategoryId = 1,
                PublisherId = 8
            }
        );
        }
    }
}
