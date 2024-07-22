using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.BookCategoryRepositories
{
    public interface IBookCategoryRepository
    {
        IEnumerable<BookCategory> GetBookCategories();
        BookCategory? GetBookCategoryById(int id);
        void AddBookCategory(BookCategory bookCategory);
        void UpdateBookCategory(BookCategory bookCategory);
        void DeleteBookCategory(BookCategory bookCategory);
    }
}
