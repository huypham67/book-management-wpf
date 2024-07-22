using BusinessObjects.Models;
using DataAccessLayer.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.BookCategoryRepositories
{
    public class BookCategoryRepository : IBookCategoryRepository
    {
        public void AddBookCategory(BookCategory bookCategory)
                => BookCategoryDAO.Instance.AddBookCategory(bookCategory);

        public void UpdateBookCategory(BookCategory bookCategory)
                => BookCategoryDAO.Instance.UpdateBookCategory(bookCategory);

        public IEnumerable<BookCategory> GetBookCategories()
                => BookCategoryDAO.Instance.GetBookCategories();
        public BookCategory? GetBookCategoryById(int id)
                => BookCategoryDAO.Instance.GetBookCategoryById(id);

        public void DeleteBookCategory(BookCategory bookCategory)
                => BookCategoryDAO.Instance.DeleteBookCategory(bookCategory);
    }
}
