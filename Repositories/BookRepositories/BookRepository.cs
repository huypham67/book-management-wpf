using BusinessObjects.Models;
using DataAccessLayer.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.BookRepositories
{
    public class BookRepository : IBookRepository
    {
        public void AddBook(Book book)
                => BookDAO.Instance.AddBook(book);
        public void UpdateBook(Book book)
                => BookDAO.Instance.UpdateBook(book);
        public void DeleteBook(Book book)
                => BookDAO.Instance.DeleteBook(book);
        public IEnumerable<Book> GetBooks()
                => BookDAO.Instance.GetBooks();
        public Book? GetBookById(int id)
                => BookDAO.Instance.GetBookById(id);
    }
}
