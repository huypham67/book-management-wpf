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
    public class BookCategoryConfiguration : IEntityTypeConfiguration<BookCategory>
    {
        public void Configure(EntityTypeBuilder<BookCategory> builder)
        {
            builder.HasKey(e => e.BookCategoryId);
            builder.Property(e => e.BookGenreType).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Description).HasMaxLength(200);
            builder.HasData(
            new BookCategory
            {
                BookCategoryId = 1,
                BookGenreType = "Fiction",
                Description = "A genre of books that contains fictional stories."
            },
            new BookCategory
            {
                BookCategoryId = 2,
                BookGenreType = "Non-Fiction",
                Description = "A genre of books that contains factual and real stories."
            },
            new BookCategory
            {
                BookCategoryId = 3,
                BookGenreType = "Mystery",
                Description = "A genre of books that deals with the solution of a crime or the unraveling of secrets."
            },
            new BookCategory
            {
                BookCategoryId = 4,
                BookGenreType = "Fantasy",
                Description = "A genre of books that contains magical or supernatural elements."
            },
            new BookCategory
            {
                BookCategoryId = 5,
                BookGenreType = "Science Fiction",
                Description = "A genre of books that deals with imaginative and futuristic concepts."
            },
            new BookCategory
            {
                BookCategoryId = 6,
                BookGenreType = "Biography",
                Description = "A genre of books that details the life of a real person."
            },
            new BookCategory
            {
                BookCategoryId = 7,
                BookGenreType = "Romance",
                Description = "A genre of books that focuses on romantic relationships."
            },
            new BookCategory
            {
                BookCategoryId = 8,
                BookGenreType = "Horror",
                Description = "A genre of books that is intended to scare or thrill the reader."
            }
        );
        }

    }
}
