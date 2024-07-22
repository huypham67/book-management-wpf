using BusinessObjects.Models;
using BusinessObjects;
using DataAccessLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.DAO
{
    public class BookDAO : SingletonBase<BookDAO>
    {
        private BookManagementDbContext _context;
        public IEnumerable<Book> GetBooks()
        {
            _context = new();
            return _context.Books
                .Include(b => b.BookCategory)
                .Include(a => a.Author)
                .Include(p => p.Publisher);
        }
        public Book? GetBookById(int id)
        {
            _context = new();
            return _context.Books.SingleOrDefault(b => b.BookId == id);
        }
        public void AddBook(Book book)
        {
            _context = new();
            _context.Add(book);
            _context.SaveChanges();
        }
        public void UpdateBook(Book book)
        {
            _context = new();
            var existingBook = _context.Books.Find(book.BookId);
            if (existingBook != null)
            {
                _context.Entry(existingBook).CurrentValues.SetValues(book);
                _context.SaveChanges();
            }
            else
            {
                // Handle the case when the book doesn't exist in the database
                throw new ArgumentException("Book not found");
            }
        }
        public void DeleteBook(Book book)
        {
            _context = new();
            _context.Remove(book);
            _context.SaveChanges();
        }
    }
}
