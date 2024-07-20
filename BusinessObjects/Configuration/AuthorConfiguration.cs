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
            builder.HasData(
            new Author
            {
                AuthorId = 1,
                AuthorName = "George Orwell",
                Biography = "George Orwell was an English novelist, essayist, journalist and critic.",
                DateOfBirth = new DateTime(1903, 6, 25),
                Nationality = "British"
            },
            new Author
            {
                AuthorId = 2,
                AuthorName = "J.K. Rowling",
                Biography = "J.K. Rowling is a British author, best known for writing the Harry Potter fantasy series.",
                DateOfBirth = new DateTime(1965, 7, 31),
                Nationality = "British"
            },
            new Author
            {
                AuthorId = 3,
                AuthorName = "Ernest Hemingway",
                Biography = "Ernest Hemingway was an American novelist, short-story writer, and journalist.",
                DateOfBirth = new DateTime(1899, 7, 21),
                Nationality = "American"
            },
            new Author
            {
                AuthorId = 4,
                AuthorName = "Jane Austen",
                Biography = "Jane Austen was an English novelist known primarily for her six major novels.",
                DateOfBirth = new DateTime(1775, 12, 16),
                Nationality = "British"
            },
            new Author
            {
                AuthorId = 5,
                AuthorName = "Mark Twain",
                Biography = "Mark Twain was an American writer, humorist, entrepreneur, publisher, and lecturer.",
                DateOfBirth = new DateTime(1835, 11, 30),
                Nationality = "American"
            },
            new Author
            {
                AuthorId = 6,
                AuthorName = "Agatha Christie",
                Biography = "Agatha Christie was an English writer known for her sixty-six detective novels.",
                DateOfBirth = new DateTime(1890, 9, 15),
                Nationality = "British"
            },
            new Author
            {
                AuthorId = 7,
                AuthorName = "Gabriel Garcia Marquez",
                Biography = "Gabriel Garcia Marquez was a Colombian novelist, short-story writer, screenwriter, and journalist.",
                DateOfBirth = new DateTime(1927, 3, 6),
                Nationality = "Colombian"
            },
            new Author
            {
                AuthorId = 8,
                AuthorName = "Leo Tolstoy",
                Biography = "Leo Tolstoy was a Russian writer who is regarded as one of the greatest authors of all time.",
                DateOfBirth = new DateTime(1828, 9, 9),
                Nationality = "Russian"
            }
        );
        }
    }
}
